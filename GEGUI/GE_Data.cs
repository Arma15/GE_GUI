using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEGUI
{

    public class HCAT
    {
        public string HcatNumber;
        public List<GE_Label> Labels;
        public HCAT()
        {
            Labels = new List<GE_Label>();
        }
    }

    public class GE_Label
    {
        public int NumSubjobs
        {
            get
            {
                return Subjobs.Count;
            }
        }
        public string EncryptedString;
        /// <summary>
        /// Unique number to identify a specific label found on a GE Product
        /// </summary>
        public string PartNumber;
        /// <summary>
        /// Description of the label
        /// </summary>
        public string ItemDescription;
        /// <summary>
        /// EX: Side, Front, Back, etc.
        /// </summary>
        public string ApproachSide;
        /// <summary>
        /// EX: Q1, Q2, Q3.. etc.
        /// </summary>
        public string PounceRegion;
        /// <summary>
        /// Can have 1 or more subjob per label
        /// </summary>
        public List<SubJob> Subjobs;

        public GE_Label()
        {
            Subjobs = new List<SubJob>();
            EncryptedString = "";
            PartNumber = "";
            ItemDescription = "";
            ApproachSide = "";
            PounceRegion = "";
        }

        /* /// <summary>
        /// Pose comes in string form as: "{0;90;90;100;90;90;100}"
        /// </summary>
        /// <param name="pose"></param>
        public void AddPose(string pose)
        {
            string temp = pose.Trim('{', '}');
            string[] nums = temp.Split(';');
            if (temp.Length != 7)
            {
                // error in format
                return;
            }

            foreach (string doub in nums)
            {
                if (double.TryParse(doub, out double num))
                {
                    RobotPose.Add(num);
                }
                else
                {
                    RobotPose.Clear();
                    return;
                }
            }
        }*/

        public int GetSubJobIndex(string jobname)
        {
            for (int i = 0; i < Subjobs.Count; ++i)
            {
                if (Subjobs[i].Name == jobname)
                {
                    return i;
                }
            }
            return -1;
        }
    }
    public class SubJob
    {
        /// <summary>
        /// Name of job file
        /// </summary>
        public string Name;
        /// <summary>/// <summary>
        /// 7 element robot position, EX: {rotary, j1, j2, j3, j4, j5, j6}
        /// </summary>
        public string RobotPose;
        /// List of tools inside that job
        /// </summary>
        public List<Tool> Tools;

        public SubJob()
        {
            Tools = new List<Tool>();
            Name = "";
            RobotPose = "";
        }
        public SubJob(string jobname, Tool newtool)
        {
            Name = jobname;
            Tools = new List<Tool>
            {
                newtool
            };
        }
    }

    public class Tool
    {
        public string ToolName;
        // In some cases can be either 1 or 2 revision numbers accepted, use string split on ':' ?
        public string Value;
        public string Tag;
        public string Type;

        public Tool()
        {
            ToolName = "";
            Value = "";
            Tag = "";
            Type = "";
        }

        public Tool(string name, string val, string tag, string tt)
        {
            ToolName = name;
            Value = val;
            Tag = tag;
            Type = tt;
        }

        public Tool(string name, string val, string tag, int tt)
        {
            ToolName = name;
            Value = val;
            Tag = tag;
            switch (tt)
            {
                case 0:
                    Type = "PF";
                    break;
                case 1:
                    Type = "OCR";
                    break;
                case 2:
                    Type = "QR";
                    break;
            }
        }
    }
}
