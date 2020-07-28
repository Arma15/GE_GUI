using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GEGUI
{
    public partial class GE_GUI : Form
    {
        public bool LookupModel;
        public List<string> DataFiles;
        private bool _newTools;
        private List<string> _currData;
        private string _currHcat;
        private string _currPartNum;
        private string _currPath;
        private GE_Label _currLabel;
        private HCAT _HCAT;

        public GE_GUI()
        {
            InitializeComponent();
            _HCAT = new HCAT();
            _currData = new List<string>();
            FolderPath.Text = @"C:\Users\kflor\OneDrive\Desktop\GEFiles\Hcat_Data";
            Hcat.Text = "H45601EA";
            PartNumber.Text = "5778198(E95)";
        }

        private void Model_TextChanged(object sender, EventArgs e)
        {
            if (Hcat.Text.Trim() == "")
            {
                ItemDescription.ReadOnly = false;
                CameraJob.ReadOnly = false;
            }
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LookUpBtn_Click(object sender, EventArgs e)
        {
            if (LoopUpBtn.Text.ToLower() == "lookup")
            {
                if (!Directory.Exists(FolderPath.Text))
                {
                    MessageBox.Show("Invalid folder path.");
                    return;
                }
                _currPath = FolderPath.Text;

                if (Hcat.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Hcat Field Empty.");
                    return;
                }
                _currHcat = Hcat.Text.Trim();
                _HCAT.HcatNumber = Hcat.Text.Trim();
                if (PartNumber.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Part Number Field Empty.");
                    return;
                }
                _currPartNum = PartNumber.Text.Trim();
                bool hcatExists = false;
                bool partNumberExists = false;
                if (_HCAT.Labels.Count < 1)
                {
                    DataFiles = new List<string>(Directory.GetFiles(_currPath, "*.txt"));
                    hcatExists = LoadAllData(DataFiles);
                }

                ToggleFields(false);
                foreach (GE_Label lab in _HCAT.Labels)
                {
                    if (lab.PartNumber.ToLower() == _currPartNum.ToLower())
                    {
                        _currLabel = lab;
                        partNumberExists = true;
                    }
                }

                if (!hcatExists)
                {
                    DialogResult = MessageBox.Show($"Hcat file not found, new file for {Hcat.Text} will be created.");
                }

                if (!partNumberExists)
                {
                    _currLabel = new GE_Label
                    {
                        Hcat = Hcat.Text.Trim(),
                        PartNumber = PartNumber.Text.Trim()
                    };
                }

                UpdatePreview();
                LoopUpBtn.Text = "New Hcat";
            }
            else
            {
                ClearFields();
                ToggleFields(true);
                LoopUpBtn.Text = "Lookup";
                _currLabel = null;
            }
        }

        private bool LoadAllData(List<string> dataFiles)
        {
            try
            {
                foreach (string fileName in dataFiles)
                {
                    if (_currPath + @"\" + _currHcat.ToLower() + ".txt" == fileName)
                    {
                        _HCAT = (JsonConvert.DeserializeObject<HCAT>(File.ReadAllText(fileName)));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when reading from files. Exception: {ex.Message}");
            }
            return false;
        }

        public void ToggleFields(bool Readonly)
        {
            ItemDescription.ReadOnly = Readonly;
            CameraJob.ReadOnly = Readonly;
            RobotPose.ReadOnly = Readonly;
            ApproachSide.ReadOnly = Readonly;
            PounceRegion.ReadOnly = Readonly;
            SubJobName.ReadOnly = Readonly;
            ToolName.ReadOnly = Readonly;
            ToolResult.ReadOnly = Readonly;
            EdhrTag.ReadOnly = Readonly;
            TypeCmb.Enabled = !Readonly;
            FolderPath.ReadOnly = !Readonly;
            Hcat.ReadOnly = !Readonly;
            PartNumber.ReadOnly = !Readonly;
        }

        public bool CheckEmptyFields()
        {
            return ItemDescription.Text.Trim() == "" || CameraJob.Text.Trim() == "" || ApproachSide.Text.Trim() == "" ||
                PounceRegion.Text.Trim() == "" || SubJobName.Text.Trim() == "" || ToolName.Text.Trim() == "" || ToolResult.Text.Trim() == "" || EdhrTag.Text.Trim() == "" ||
                TypeCmb.SelectedIndex < 0;
        }

        public void ClearFields()
        {
            Hcat.Text = "";
            PartNumber.Text = "";
            ItemDescription.Text = "";
            CameraJob.Text = "";
            RobotPose.Text = "";
            ApproachSide.Text = "";
            PounceRegion.Text = "";
            SubJobName.Text = "";
            ToolName.Text = "";
            ToolResult.Text = "";
            EdhrTag.Text = "";
            MiniPreview.Text = "";
            TypeCmb.SelectedIndex = -1;
        }

        private void UpdatePreview()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Current Hcat -> " + _currHcat);
            sb.AppendLine($"Part Number -> {_currLabel.PartNumber}");

            _currLabel.ItemDescription = _currLabel.ItemDescription == "" ? ItemDescription.Text.Trim() : _currLabel.ItemDescription;
            sb.AppendLine($"Item Description -> {_currLabel.ItemDescription}");

            _currLabel.CameraJobName = _currLabel.CameraJobName == "" ? CameraJob.Text.Trim() : _currLabel.CameraJobName;
            sb.AppendLine($"Camera Job -> {_currLabel.CameraJobName}");

            _currLabel.RobotPose = _currLabel.RobotPose == "" ? RobotPose.Text.Trim() : _currLabel.RobotPose;
            sb.AppendLine($"Working Pose -> {_currLabel.RobotPose.Replace(';', ',')}");

            _currLabel.ApproachSide = _currLabel.ApproachSide == "" ? ApproachSide.Text.Trim() : _currLabel.ApproachSide;
            sb.AppendLine($"Approach Side -> {_currLabel.ApproachSide}");

            _currLabel.PounceRegion = _currLabel.PounceRegion == "" ? PounceRegion.Text.Trim() : _currLabel.PounceRegion;
            sb.AppendLine($"Pounce Region -> {_currLabel.PounceRegion}");

            sb.AppendLine($"Inspection Details:");

            foreach (SubJob sj in _currLabel.CameraSubjobs)
            {
                foreach (Tool t in sj.Tools)
                {
                    sb.AppendLine($"\tSubJob Name -> {t.SubjobName}");
                    sb.AppendLine($"\tTool Name -> {t.ToolName}");
                    sb.AppendLine($"\tExpected Result -> {t.Value}");
                    sb.AppendLine($"\teDHR Tag -> {t.Tag}");
                    sb.AppendLine($"\tType -> {t.Type}");
                    sb.AppendLine();
                }
            }
            MiniPreview.Text = sb.ToString();
        }

        private void AddToolBtn_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Complete Empty Fields before adding.");
                return;
            }
            if (ToolExists(ToolName.Text.Trim()))
            {
                MessageBox.Show($"Tool Name: {ToolName.Text.Trim()} already exists in the current label.");
                return;
            }
            Tool newTool = new Tool(SubJobName.Text.Trim(), ToolName.Text.Trim(), ToolResult.Text.Trim(), EdhrTag.Text.Trim(), TypeCmb.SelectedIndex);
            bool exists = false;
            for (int i = 0; i < _currLabel.CameraSubjobs.Count; ++i)
            {
                if (_currLabel.CameraSubjobs[i].JobName.ToLower() == SubJobName.Text.Trim().ToLower())
                {
                    for (int j = 0; j < _currLabel.CameraSubjobs[i].Tools.Count; ++j)
                    {
                        if (_currLabel.CameraSubjobs[i].Tools[j].ToolName.ToLower() == SubJobName.Text.Trim().ToLower())
                        {
                            DialogResult result = MessageBox.Show($"Tool {ToolName.Text.Trim()} already exists, modify existing tool?", "Confirmation", MessageBoxButtons.YesNoCancel);
                            if (result == DialogResult.Yes)
                            {
                                _currLabel.CameraSubjobs[i].Tools.RemoveAt(j);
                                _currLabel.CameraSubjobs.Add(new SubJob(SubJobName.Text.Trim(), newTool));
                                _newTools = true;
                                ClearTool();
                                UpdatePreview();
                                return;
                            }
                            else if (result == DialogResult.No)
                            {
                                ClearTool();
                            }
                            else
                            {
                                SubJobName.Focus();
                            }
                        }
                    }

                    _currLabel.CameraSubjobs[i].Tools.Add(newTool);
                    exists = true;
                    _newTools = true;
                    break;
                }
            }

            if (!exists)
            {
                DialogResult result = MessageBox.Show($"Subjob: \"{SubJobName.Text.Trim()}\" does not exist yet, add new subjob?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    _currLabel.CameraSubjobs.Add(new SubJob(SubJobName.Text.Trim(), newTool));
                    _newTools = true;
                    ClearTool();
                }
                else if (result == DialogResult.No)
                {
                    ClearTool();
                }
                else
                {
                    SubJobName.Focus();
                }
            }
            UpdatePreview();
        }

        private bool ToolExists(string toolName)
        {
            foreach (SubJob sj in _currLabel.CameraSubjobs)
            {
                foreach (Tool t in sj.Tools)
                {
                    if (t.ToolName.ToLower() == ToolName.Text.Trim().ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ClearTool()
        {
            SubJobName.Text = "";
            ToolName.Text = "";
            ToolResult.Text = "";
            EdhrTag.Text = "";
            TypeCmb.SelectedIndex = -1;
        }

        private void AddAllBtn_Click(object sender, EventArgs e)
        {
            if (ItemDescription.Text.Trim() == "" || CameraJob.Text.Trim() == "" || ApproachSide.Text.Trim() == "" ||
                PounceRegion.Text.Trim() == "")
            {
                MessageBox.Show("Complete empty fields before submitting data.", "Empty Fields");
                return;
            }

            if (!_newTools)
            {
                DialogResult result = MessageBox.Show("No new tools added, please ensure you have selected the Add button to add new tools. Save anyways?", "No new tools added", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            if (ItemDescription.Text.Trim().ToLower() != _currLabel.ItemDescription.ToLower())
            {
                DialogResult result = MessageBox.Show($"Item Description has changed from {_currLabel.ItemDescription} to {ItemDescription.Text.Trim()}, modify in file too?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _currLabel.ItemDescription = ItemDescription.Text.Trim();
                }
                else
                {
                    ItemDescription.Text = _currLabel.ItemDescription;
                }
            }
            if (CameraJob.Text.Trim().ToLower() != _currLabel.CameraJobName.ToLower())
            {
                DialogResult result = MessageBox.Show($"Camera Job has changed from {_currLabel.CameraJobName} to {CameraJob.Text.Trim()}, modify in file too?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _currLabel.CameraJobName = CameraJob.Text.Trim();
                }
                else
                {
                    CameraJob.Text = _currLabel.CameraJobName;
                }
            }
            if (RobotPose.Text.Trim().ToLower() != _currLabel.RobotPose.ToLower())
            {
                DialogResult result = MessageBox.Show($"Working Pose has changed from {_currLabel.RobotPose} to {RobotPose.Text.Trim()}, modify in file too?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _currLabel.RobotPose = RobotPose.Text.Trim();
                }
                else
                {
                    RobotPose.Text = _currLabel.RobotPose;
                }
            }
            if (ApproachSide.Text.Trim().ToLower() != _currLabel.ApproachSide.ToLower())
            {
                DialogResult result = MessageBox.Show($"Approach Side has been changed from {_currLabel.ApproachSide} to {ApproachSide.Text.Trim()}, modify in file too?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _currLabel.ApproachSide = ApproachSide.Text.Trim();
                }
                else
                {
                    ApproachSide.Text = _currLabel.ApproachSide;
                }
            }
            if (PounceRegion.Text.Trim().ToLower() != _currLabel.PounceRegion.ToLower())
            {
                DialogResult result = MessageBox.Show($"Pounce Region has been changed from {_currLabel.PounceRegion} to {PounceRegion.Text.Trim()}, modify in file too?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _currLabel.PounceRegion = PounceRegion.Text.Trim();
                }
                else
                {
                    PounceRegion.Text = _currLabel.PounceRegion;
                }
            }

            int index = LabelExists(_currLabel.PartNumber);
            if (index  != -1)
            {
                _HCAT.Labels.RemoveAt(index);
            }
            _HCAT.Labels.Add(_currLabel);

            try
            {
                string newPath = _currPath + @"/" + _HCAT.HcatNumber.ToLower() + ".txt";
                string output = JsonConvert.SerializeObject(_HCAT, Formatting.Indented);

                //write string to file
                File.WriteAllText(newPath, output);

                // Get current list of data files
                DataFiles = new List<string>(Directory.GetFiles(_currPath, "*.txt"));
                MessageBox.Show($"Data added successfully at {_currPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data failed to write to path: {_currPath}, exception: {ex.Message}");
            }
        }

        private int LabelExists(string partNumber)
        {
            for (int i = 0; i < _HCAT.Labels.Count; ++i)
            {
                if (_HCAT.Labels[i].PartNumber.ToLower() == partNumber.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        private void RemoveTool_Click(object sender, EventArgs e)
        {
            if (ToolRemove.Text.Trim() == "")
            {
                MessageBox.Show("Tool Name field empty.");
                return;
            }

            for (int i = 0; i < _currLabel.CameraSubjobs.Count; ++i)
            {
                for (int j = 0; j < _currLabel.CameraSubjobs[i].Tools.Count; ++j)
                {
                    if (_currLabel.CameraSubjobs[i].Tools[j].ToolName.ToLower() == ToolRemove.Text.Trim().ToLower())
                    {
                        DialogResult result = MessageBox.Show($"Remove Tool: {_currLabel.CameraSubjobs[i].Tools[j].ToolName}?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            _currLabel.CameraSubjobs[i].Tools.RemoveAt(j);
                        }
                        ToolRemove.Text = "";
                        return;
                    }
                }
            }
            MessageBox.Show($"Tool Name: {ToolRemove.Text.Trim()} not found.");
            ToolRemove.Focus();
        }

        private void NewPartNumberbtn_Click(object sender, EventArgs e)
        {
            PartNumber.ReadOnly = false;
            SetPartNumberbtn.Enabled = true;
            PartNumber.Text = "";
            ItemDescription.Text = "";
            CameraJob.Text = "";
            RobotPose.Text = "";
            ApproachSide.Text = "";
            PounceRegion.Text = "";
            ClearTool();
            MiniPreview.Text = "";
        }

        private void SetPartNumberbtn_Click(object sender, EventArgs e)
        {
            int index = LabelExists(PartNumber.Text.Trim());
            if (index == -1)
            {
                DialogResult result = MessageBox.Show($"Part Number: {PartNumber.Text.Trim()} does not exist yet in the dictionary, continue?", "New Part Number Detected", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _currLabel = new GE_Label();
                    _currLabel.Hcat = Hcat.Text.Trim();
                    _currLabel.PartNumber = PartNumber.Text.Trim();
                }
                else
                {
                    PartNumber.Focus();
                    return;
                }
            }
            else
            {
                _currLabel = _HCAT.Labels[index];
                PartNumber.ReadOnly = true;
                SetPartNumberbtn.Enabled = false;
                UpdatePreview();
            }
        }
    }
}