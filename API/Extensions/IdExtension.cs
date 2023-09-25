using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class IdExtension
    {
      public static int GenerateUniqueIntId(){
        Guid uniqueGuid = Guid.NewGuid();
        int uniqueIntId = uniqueGuid.GetHashCode();

         // Ensure the generated integer ID is non-negative
        if (uniqueIntId < 0)
        {
        uniqueIntId = -uniqueIntId;
        }

        return uniqueIntId;
        }
    }
}