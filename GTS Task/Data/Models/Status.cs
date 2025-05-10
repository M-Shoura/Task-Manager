using System.Runtime.Serialization;

namespace GTS_Task.Data.Models
{
    public enum Status
    {
        [EnumMember(Value = "Pending")]
        Pending,
        
        [EnumMember(Value = "In Progress")]
        InProgress,
        
        [EnumMember(Value = "Completed")]
        Completed
    }
}