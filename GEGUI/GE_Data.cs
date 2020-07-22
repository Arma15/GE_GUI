using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEGUI
{
    public class GE_Label
    {
        /// <summary>
        /// Unique number to identify a specific label found on a GE Product
        /// </summary>
        public string Label;
        /// <summary>
        /// 7 element robot position, EX: {rotary, j1, j2, j3, j4, j5, j6}
        /// </summary>
        public List<double> RobotPose;
        /// <summary>
        /// Data structure with name of .job and its details
        /// </summary>
        public MachineJob CurrentJob;
        /// <summary>
        /// EX: Side, Front, Back, etc.
        /// </summary>
        public string ApproachSide;
        /// <summary>
        /// EX: Q1, Q2, Q3.. etc.
        /// </summary>
        public string PounceRegion;
        /// <summary>
        /// Can have 1 or more results to send back to edhr
        /// </summary>
        public MachineJob CameraJob;
    }

    public class MachineJob
    {
        /// <summary>
        /// Name of job file
        /// </summary>
        public string JobName;
        /// <summary>
        /// List of tools inside that job
        /// </summary>
        public List<Tool> Tools;
    }

    public class Tool
    {
        public string ToolName;
        public string Value;
        public string Tag;
        public ToolType Type;
        
        public Tool(string name, string val, string tag, int tt)
        {
            ToolName = name;
            Value = val;
            Tag = tag;
            Type = (ToolType)tt;
        }
    }

    public enum ToolType
    {
        PF,
        OCR,
        QR
    }

}
