using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.TourAggregate
{
    public enum TourStatus
    {
        [EnumMember(Value = "Completed")]
        Completed,

        [EnumMember(Value = "Current")]
        Current,

        [EnumMember(Value = "Canceled")]
        Canceled
    }
}
