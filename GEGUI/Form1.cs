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
        private string _currHcat;
        private string _currPartNum;
        private string _currPath;
        private GE_Label _currLabel;
        private string _currSubJob;
        private HCAT _HCAT;

        public GE_GUI()
        {
            InitializeComponent();
            _HCAT = new HCAT();
            //FolderPath.Text = @"C:\Users\kflor\OneDrive\Desktop\GEFiles\Hcat_Data";
            Hcat.Text = "master";
            //PartNumber.Text = "5778198(E95)";
        }

        private void Model_TextChanged(object sender, EventArgs e)
        {
            if (Hcat.Text.Trim() == "")
            {
                ItemDescription.ReadOnly = false;
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
                if (!Directory.Exists(FolderPath.Text.Trim()))
                {
                    MessageBox.Show("Invalid folder path.");
                    return;
                }
                if (Hcat.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Hcat field empty.");
                    return;
                }
                if (PartNumber.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Part number field empty.");
                    return;
                }

                _newTools = false;
                _currPath = FolderPath.Text.Trim();
                _currHcat = _HCAT.HcatNumber = Hcat.Text.Trim();
                _currPartNum = PartNumber.Text.Trim();
                
                DataFiles = new List<string>(Directory.GetFiles(_currPath, "*.txt"));
                bool hcatExists = LoadAllData(DataFiles);
                bool partNumberExists = false;
                
                if (!hcatExists)
                {
                    DialogResult = MessageBox.Show($"Hcat file not found, new file for: {Hcat.Text}, will be created.");
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

                if (!partNumberExists)
                {
                    _currLabel = new GE_Label
                    {
                        PartNumber = PartNumber.Text.Trim()
                    };
                }
                else
                {
                    ItemDescription.Text = _currLabel.ItemDescription;
                    ApproachCmb.SelectedIndex = _currLabel.ApproachSide.ToLower() == "front" ? 0 : 1;
                    PounceCmb.SelectedIndex = _currLabel.PounceRegion.ToLower() == "q1" ? 0 : _currLabel.PounceRegion.ToLower() == "q2" ? 1 
                        : _currLabel.PounceRegion.ToLower() == "q3" ? 2 : _currLabel.PounceRegion.ToLower() == "q4" ? 3 : -1;
                }

                UpdatePreview();
                LoopUpBtn.Text = "New Hcat";
                SubjobSetBtn.Enabled = true;
            }
            else
            {
                ClearFields();
                ToggleFields(true);
                LoopUpBtn.Text = "Lookup";
                SubjobSetBtn.Enabled = false;
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
            FolderPath.ReadOnly = !Readonly;
            Hcat.ReadOnly = !Readonly;
            PartNumber.ReadOnly = !Readonly;

            ItemDescription.ReadOnly = Readonly;
            ApproachCmb.Enabled = !Readonly;
            PounceCmb.Enabled = !Readonly;

            SubJobName.ReadOnly = Readonly;
            RobotPose.ReadOnly = Readonly;
            
            ToolName.ReadOnly = Readonly;
            ToolResult.ReadOnly = Readonly;
            EdhrTag.ReadOnly = Readonly;
            TypeCmb.Enabled = !Readonly;
        }

        public bool CheckEmptyFields()
        {
            return ItemDescription.Text.Trim() == "" || ApproachCmb.SelectedIndex < 0 || PounceCmb.SelectedIndex < 0 ||
              SubJobName.Text.Trim() == "" || ToolName.Text.Trim() == "" || ToolResult.Text.Trim() == "" || EdhrTag.Text.Trim() == "" ||
                TypeCmb.SelectedIndex < 0;
        }

        public void ClearFields()
        {
            Hcat.Text = "";
            PartNumber.Text = "";
            ItemDescription.Text = "";

            SubJobName.Text = "";
            RobotPose.Text = "";

            ToolName.Text = "";
            ToolResult.Text = "";
            EdhrTag.Text = "";
            MiniPreview.Text = "";

            TypeCmb.SelectedIndex = -1;
            ApproachCmb.SelectedIndex = -1;
            PounceCmb.SelectedIndex = -1;
        }

        private void UpdatePreview()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Current Hcat -> " + _currHcat);
            sb.AppendLine($"Part Number -> {_currLabel.PartNumber}");

            _currLabel.ItemDescription = _currLabel.ItemDescription == "" ? ItemDescription.Text.Trim() : _currLabel.ItemDescription;
            sb.AppendLine($"Item Description -> {_currLabel.ItemDescription}");

            _currLabel.ApproachSide = _currLabel.ApproachSide == "" ? ApproachCmb.Text : _currLabel.ApproachSide;
            sb.AppendLine($"Approach Side -> {_currLabel.ApproachSide}");

            _currLabel.PounceRegion = _currLabel.PounceRegion == "" ? PounceCmb.Text : _currLabel.PounceRegion;
            sb.AppendLine($"Pounce Region -> {_currLabel.PounceRegion}");

            foreach (SubJob sj in _currLabel.Subjobs)
            {
                // Subjob info
                sb.AppendLine();
                sb.AppendLine($"SubJob Name -> {sj.Name}");
                sb.AppendLine($"Working Pose -> {sj.RobotPose}");

                sb.AppendLine($"Inspection Details:");
                foreach (Tool t in sj.Tools)
                {
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
                DialogResult result = MessageBox.Show($"Tool {ToolName.Text.Trim()} already exists, modify existing tool?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < _currLabel.Subjobs.Count; ++i)
                    {
                        if (_currLabel.Subjobs[i].Name.ToLower() == SubJobName.Text.Trim().ToLower())
                        {
                            for (int j = 0; j < _currLabel.Subjobs[i].Tools.Count; ++j)
                            {
                                if (_currLabel.Subjobs[i].Tools[j].ToolName.ToLower() == SubJobName.Text.Trim().ToLower())
                                {
                                    _currLabel.Subjobs[i].Tools[j].Tag = EdhrTag.Text.Trim();
                                    _currLabel.Subjobs[i].Tools[j].ToolName = ToolName.Text.Trim();
                                    _currLabel.Subjobs[i].Tools[j].Type = GetType(TypeCmb.SelectedIndex);
                                    _currLabel.Subjobs[i].Tools[j].Value = ToolResult.Text.Trim();
                                    _newTools = true;
                                    ClearTool();
                                    UpdatePreview();
                                    return;
                                }
                            }
                        }
                    }
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
            else
            {
                _currLabel.Subjobs[_currLabel.GetSubJobIndex(_currSubJob)].Tools.Add(new Tool(ToolName.Text.Trim(), ToolResult.Text.Trim(), EdhrTag.Text.Trim(), TypeCmb.SelectedIndex));
                ClearTool();
                UpdatePreview();
            }
        }

        private string GetType(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return "PF";
                case 1:
                    return "OCR";
                case 2:
                    return "QR";
                default:
                    return "";
            }
        }

        private bool ToolExists(string toolName)
        {
            foreach (SubJob sj in _currLabel.Subjobs)
            {
                foreach (Tool t in sj.Tools)
                {
                    if (t.ToolName.ToLower() == toolName.ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ClearTool()
        {
            ToolName.Text = "";
            ToolResult.Text = "";
            EdhrTag.Text = "";
            TypeCmb.SelectedIndex = -1;
        }

        private void AddAllBtn_Click(object sender, EventArgs e)
        {
            if (ItemDescription.Text.Trim() == "" || ApproachCmb.SelectedIndex < 0 ||
                PounceCmb.SelectedIndex < 0)
            {
                MessageBox.Show("Complete empty fields before submitting data.", "Empty Fields");
                return;
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
            // Make sure to add current label and current subjob to this object before writing to file
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

            for (int i = 0; i < _currLabel.Subjobs.Count; ++i)
            {
                for (int j = 0; j < _currLabel.Subjobs[i].Tools.Count; ++j)
                {
                    if (_currLabel.Subjobs[i].Tools[j].ToolName.ToLower() == ToolRemove.Text.Trim().ToLower())
                    {
                        DialogResult result = MessageBox.Show($"Remove Tool: {_currLabel.Subjobs[i].Tools[j].ToolName}?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            _currLabel.Subjobs[i].Tools.RemoveAt(j);
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
            _newTools = false;
            PartNumber.ReadOnly = false;
            SetPartNumberbtn.Enabled = true;
            PartNumber.Text = "";
            ItemDescription.Text = "";
            RobotPose.Text = "";
            ApproachCmb.SelectedIndex = -1;
            PounceCmb.SelectedIndex = -1;
            SubJobName.Text = "";
            SubJobName.ReadOnly = false;
            RobotPose.Text = "";
            RobotPose.ReadOnly = false;
            SubjobSetBtn.Text = "Set";
            PoseSetBtn.Text = "Set";
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
                    _currLabel = new GE_Label
                    {
                        PartNumber = PartNumber.Text.Trim()
                    };
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

        private void SubjobSetBtn_Click(object sender, EventArgs e)
        {
            if (SubjobSetBtn.Text == "Set")
            {
                if (SubJobName.Text.Trim() == "")
                {
                    MessageBox.Show("Empty SubJob field.");
                    return;
                }
                SubjobSetBtn.Text = "Modify";
                RobotPose.ReadOnly = false;
                PoseSetBtn.Enabled = true;
                _currSubJob = SubJobName.Text.Trim();
                bool found = false;
                foreach (SubJob sj in _currLabel.Subjobs)
                {
                    if (SubJobName.Text.ToLower() == sj.Name.ToLower())
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    SubJobName.ReadOnly = true;
                    RobotPose.Text = _currLabel.Subjobs[_currLabel.GetSubJobIndex(_currSubJob)].RobotPose;
                    RobotPose.ReadOnly = true;
                    PoseSetBtn.Enabled = true;
                    PoseSetBtn.Text = "Modify";
                }
                else
                {
                    DialogResult result = MessageBox.Show($"SubJob: {SubJobName.Text.Trim()} does not exist, add it to current data?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        SubJobName.ReadOnly = true;
                        _currLabel.Subjobs.Add(new SubJob(SubJobName.Text.Trim()));
                    }
                    else
                    {
                        SubJobName.Text = "";
                    }
                }
            }
            else
            {
                SubJobName.Text = "";
                RobotPose.Text = "";
                RobotPose.ReadOnly = false;
                SubJobName.ReadOnly = false;
                SubjobSetBtn.Text = "Set";
                PoseSetBtn.Text = "Set";
                ClearTool();
            }
        }

        private void PoseSetBtn_Click(object sender, EventArgs e)
        {
            if (PoseSetBtn.Text == "Set")
            {
                if (RobotPose.Text.Trim() == "")
                {
                    MessageBox.Show("Empty Working Pose field.");
                    return;
                }
                _currLabel.Subjobs[_currLabel.GetSubJobIndex(_currSubJob)].RobotPose = RobotPose.Text.Trim();
                PoseSetBtn.Text = "Modify";
                RobotPose.ReadOnly = true;
            }
            else
            {
                PoseSetBtn.Text = "Set";
                RobotPose.ReadOnly = false;
            }
        }
    }
}