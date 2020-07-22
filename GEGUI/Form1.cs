using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GEGUI
{
    public partial class GE_GUI : Form
    {
        public class Tool
        {
            public string SubjobName;
            public string ToolName;
            public string Value;
            public string Tag;
            public ToolType Type;

            public Tool(string SubName, string name, string val, string tag, int tt)
            {
                SubjobName = SubName;
                ToolName = name;
                Value = val;
                Tag = tag;
                Type = (ToolType)tt;
            }

            public Tool(string SubName, string name, string val, string tag, string tt)
            {
                SubjobName = SubName;
                ToolName = name;
                Value = val;
                Tag = tag;

                switch (tt.ToLower())
                {
                    case "pf":
                        Type = ToolType.PF;
                        break;
                    case "ocr":
                        Type = ToolType.OCR;
                        break;
                    case "qr":
                        Type = ToolType.QR;
                        break;
                }
            }

            public override string ToString()
            {
                return SubjobName + ":" + ToolName + ":" + Value + ":" + Tag + ":" + Type.ToString();
            }
        }

        public enum ToolType
        {
            PF,
            OCR,
            QR
        }

        public bool LookupModel;
        public string[] DataFiles;
        private bool _newHcat;
        private bool _newPartNumber;
        private List<string> _currData;
        private string _currHcat;
        private string _currPartNum;
        private string _currCameraJob;
        private string _currApproachSide;
        private string _currPounceRegion;
        private List<Tool> _currTools;
        private string _currPath;
        private string _currItemDescription;
        private string _currWorkingPose;
        private string _currType;
        private string _currPreview;
        private int _currIndex;

        public GE_GUI()
        {
            InitializeComponent();
            _currData = new List<string>();
            _currTools = new List<Tool>();
            _newHcat = false;
            _newPartNumber = false;
            FolderPath.Text = @"C:\Users\kflor\OneDrive\Desktop\GEFiles\Hcat_Data";
            Hcat.Text = "H45601EA";
            PartNumber.Text = "5778198(E95)";
            _currIndex = 0;
        }

        private void Model_TextChanged(object sender, EventArgs e)
        {
            if (Hcat.Text.Trim() == "")
            {
                ItemDescription.ReadOnly = false;
                CameraJob.ReadOnly = false;
            }
        }

        private void TypeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCmb.SelectedIndex > 0)
            {
                _currType = TypeCmb.SelectedItem.ToString();
            }
        }

        // string[] lines = File.ReadAllLines(textFile);

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
                string hcat = Hcat.Text.Trim();

                if (PartNumber.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Part Number Field Empty.");
                    return;
                }
                ToggleFields(false);
                _currPartNum = PartNumber.Text.Trim();
                _currHcat = hcat;
                DataFiles = Directory.GetFiles(_currPath, "*.txt");
                bool exists = false;

                for (int i = 0; i < DataFiles.Length; ++i)
                {
                    string filename = Path.GetFileName(DataFiles[i]);
                    if (filename == (hcat + ".txt"))
                    {
                        exists = true;
                        _currIndex = i;
                        break;
                    }
                }

                if (!exists)
                {
                    MessageBox.Show($"Hcat file not found, new file for {Hcat.Text} will be created.");
                    _newHcat = true;
                    _newPartNumber = true;
                }
                else
                {
                    _currData = new List<string>(GetFileData(hcat));
                    if (_currData.Count < 1)
                    {
                        MessageBox.Show($"Hcat file {Hcat.Text} is empty, part number {PartNumber.Text} will be added.");
                        _newPartNumber = true;
                    }
                    else
                    {
                        FillDisplay();
                    }
                }

                LoopUpBtn.Text = "New Hcat";
            }
            else
            {
                ClearFields();
                ToggleFields(true);
                TypeCmb.SelectedIndex = -1;
                _newHcat = false;
                _newPartNumber = false;
                LoopUpBtn.Text = "Lookup";
                _currTools.Clear();
            }
        }

        public void ToggleFields(bool Readonly)
        {
            ItemDescription.ReadOnly = Readonly;
            CameraJob.ReadOnly = Readonly;
            WorkingPose.ReadOnly = Readonly;
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
        public bool EmptyFields()
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
            WorkingPose.Text = "";
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

            sb.AppendLine($"Part Number -> {_currPartNum}");
            sb.AppendLine($"Item Description -> {_currItemDescription}");
            sb.AppendLine($"Camera Job -> {_currCameraJob}");
            sb.AppendLine($"Working Pose -> {_currWorkingPose.Replace(';', ',')}");
            sb.AppendLine($"Approach Side -> {_currApproachSide}");
            sb.AppendLine($"Pounce Region -> {_currPounceRegion}");
            sb.AppendLine($"Inspection Details:");

            foreach (Tool tool in _currTools)
            {
                sb.AppendLine($"\tSubJob -> {tool.SubjobName}");
                sb.AppendLine($"\tTool Name -> {tool.ToolName}");
                sb.AppendLine($"\tExpected Result -> {tool.Value}");
                sb.AppendLine($"\teDHR Tag -> {tool.Tag}");
                sb.AppendLine($"\tType -> {tool.Type.ToString()}");
                sb.AppendLine();
            }
            MiniPreview.Text = sb.ToString();
            _currPreview = sb.ToString();
        }

        private void FillDisplay()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Current Hcat -> " + _currHcat);

            foreach (string line in _currData)
            {
                string[] fields = line.Split(',');
                if (fields.Length < 1)
                {
                    continue;
                }
                if (fields.Length != 7)
                {
                    MessageBox.Show("Error: File format not as expected.");
                    return;
                }
                if (fields[0] == _currPartNum)
                {
                    _currItemDescription = fields[0];
                    ItemDescription.Text = fields[1];
                    _currCameraJob = fields[5];
                    CameraJob.Text = fields[5];
                    _currWorkingPose = fields[4];
                    WorkingPose.Text = fields[4].Replace(';', ',');
                    _currApproachSide = fields[2];
                    ApproachSide.Text = fields[2];
                    _currPounceRegion = fields[3];
                    PounceRegion.Text = fields[3];

                    sb.AppendLine($"Part Number -> {fields[0]}");
                    sb.AppendLine($"Item Description -> {fields[1]}");
                    sb.AppendLine($"Camera Job -> {fields[5]}");
                    sb.AppendLine($"Working Pose -> {fields[4].Replace(';', ',')}");
                    sb.AppendLine($"Approach Side -> {fields[2]}");
                    sb.AppendLine($"Pounce Region -> {fields[3]}");
                    sb.AppendLine($"Inspection Details:");
                    string[] details = fields[6].Split(';');

                    foreach (string str in details)
                    {
                        string[] results = str.Split(':');
                        sb.AppendLine($"\tSubJob Name -> {results[0]}");
                        sb.AppendLine($"\tTool Name -> {results[1]}");
                        sb.AppendLine($"\tExpected Result -> {results[2]}");
                        sb.AppendLine($"\teDHR Tag -> {results[3]}");
                        sb.AppendLine($"\tType -> {results[4]}");
                        sb.AppendLine();
                        _currTools.Add(new Tool(results[0], results[1], results[2], results[3], results[4]));
                    }
                    sb.AppendLine();
                }
            }
            MiniPreview.Text = sb.ToString();
            _currPreview = sb.ToString();
        }

        private string[] GetFileData(string Hcat)
        {
            return File.ReadAllLines($"{_currPath}\\{Hcat}.txt", Encoding.UTF8);
        }

        private void AddTagBtn_Click(object sender, EventArgs e)
        {
            if (EmptyFields())
            {
                MessageBox.Show("Complete Empty Fields before adding.");
                return;
            }
            Tool newTool = new Tool(SubJobName.Text.Trim(), ToolName.Text.Trim(), ToolResult.Text.Trim(), EdhrTag.Text.Trim(), TypeCmb.SelectedIndex);

            _currTools.Add(newTool);
            _currPartNum = PartNumber.Text.Trim();
            _currItemDescription = ItemDescription.Text.Trim();
            _currApproachSide = ApproachSide.Text.Trim();
            _currPounceRegion = PounceRegion.Text.Trim();
            _currWorkingPose = WorkingPose.Text.Trim();
            _currCameraJob = CameraJob.Text.Trim();

            UpdatePreview();
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
                MessageBox.Show("Complete empty fields before submitting data.");
            }

            if (_currTools.Count < 1)
            {
                MessageBox.Show("No new tools added, please ensure you have selected the Add Tag button.");
            }

            string filePath = _currPath + '\\' + _currHcat + ".txt";
            // need create file if does not exist
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            // string[] lines = File.ReadAllLines(textFile);
            List<string> data = new List<string>(File.ReadAllLines(filePath));
            string newLine = "";
            bool exists = false;
            for (int i = 0; i < data.Count; ++i)
            {
                string[] terms = data[i].Split(',');
                if (terms[0].ToLower() == _currPartNum.ToLower())
                {
                    exists = true;
                    newLine = data[i];
                    data.RemoveAt(i);
                    break;
                }
            }

            // hcat exists but this is additional part number (append to existing file)
            if (exists)
            {
                // Append data to existing line
                StringBuilder sb = new StringBuilder(newLine);
                sb.Append(";");
                for (int i = 0; i < _currTools.Count; ++i)
                {
                    sb.Append(_currTools[i].ToString());
                    if (i != _currTools.Count - 1)
                    {
                        sb.Append(";");
                    }
                }

                data.Add(sb.ToString());
            }
            else
            {
                // Create new line
                StringBuilder sb = new StringBuilder(newLine);
                sb.Append(_currPartNum);
                sb.Append(",");
                sb.Append(_currItemDescription);
                sb.Append(",");
                sb.Append(_currApproachSide);
                sb.Append(",");
                sb.Append(_currPounceRegion);
                sb.Append(",");
                sb.Append(_currWorkingPose.Replace(',', ';'));
                sb.Append(",");
                sb.Append(_currCameraJob);
                sb.Append(",");

                for (int i = 0; i < _currTools.Count; ++i)
                {
                    sb.Append(_currTools[i].SubjobName);
                    sb.Append(":");
                    sb.Append(_currTools[i].ToolName);
                    sb.Append(":");
                    sb.Append(_currTools[i].Value);
                    sb.Append(":");
                    sb.Append(_currTools[i].Tag);
                    sb.Append(":");
                    sb.Append(_currTools[i].Type.ToString());

                    if (i != _currTools.Count - 1)
                    {
                        sb.Append(";");
                    }
                }
                data.Add(sb.ToString());
            }
            File.WriteAllLines(filePath, data);
            MessageBox.Show($"Data added successfully at {filePath}");
        }
    }
}