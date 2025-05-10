using System.Runtime.Serialization;

namespace GTS_Task.Data.Models
{
    public enum Priority
    {
        [EnumMember(Value = "Low")]
        Low,
        [EnumMember(Value = "Medium")]
        Medium,
        [EnumMember(Value = "High")]
        High
    }
}