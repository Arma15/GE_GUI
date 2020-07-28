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
                return CameraSubjobs.Count;
            }
        }
        public string Hcat;

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
        /// 7 element robot position, EX: {rotary, j1, j2, j3, j4, j5, j6}
        /// </summary>
        public string RobotPose;
        /// <summary>
        /// EX: Side, Front, Back, etc.
        /// </summary>
        public string ApproachSide;
        /// <summary>
        /// EX: Q1, Q2, Q3.. etc.
        /// </summary>
        public string PounceRegion;
        /// <summary>
        /// The full camera job name, ie. GE_Label.job
        /// </summary>
        public string CameraJobName;
        /// <summary>
        /// Can have 1 or more subjob per label
        /// </summary>
        public List<SubJob> CameraSubjobs;

        public GE_Label()
        {
            CameraSubjobs = new List<SubJob>();
            EncryptedString = "";
            PartNumber = "";
            ItemDescription = "";
            RobotPose = "";
            ApproachSide = "";
            PounceRegion = "";
            CameraJobName = "";
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

        public string GetPose()
        {
            StringBuilder sb = new StringBuilder();
            foreach (double d in RobotPose)
            {
                sb.Append(d.ToString());
            }
            return sb.ToString();
        }

        public int GetSubJobIndex(string jobname)
        {
            for (int i = 0; i < CameraSubjobs.Count; ++i)
            {
                if (CameraSubjobs[i].JobName == jobname)
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
        public string JobName;
        /// <summary>
        /// List of tools inside that job
        /// </summary>
        public List<Tool> Tools;

        public SubJob()
        {
            Tools = new List<Tool>();
            JobName = "";
        }
        public SubJob(string jobname, Tool newtool)
        {
            JobName = jobname;
            Tools = new List<Tool>
            {
                newtool
            };
        }
    }

    public class Tool
    {
        public string SubjobName;
        public string ToolName;
        // In some cases can be either 1 or 2 revision numbers accepted, use string split on ':' ?
        public string Value;
        public string Tag;
        public string Type;

        public Tool()
        {
            SubjobName = "";
            ToolName = "";
            Value = "";
            Tag = "";
            Type = "";
        }

        public Tool(string SubName, string name, string val, string tag, string tt)
        {
            SubjobName = SubName;
            ToolName = name;
            Value = val;
            Tag = tag;
            Type = tt;
        }

        public Tool(string SubName, string name, string val, string tag, int tt)
        {
            SubjobName = SubName;
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
