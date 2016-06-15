using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scyts.Shopping.Bll
{
   public class BsProvider
    {
        public static IT CreateBusiness<IT>() where IT : class
        {
            Type type = Type.GetType(typeof(BsProvider).Assembly.GetName().Name + ".Impl." + typeof(IT).Name.Substring(1));
            return (IT)Activator.CreateInstance(type);
        }

        public static ICommon<T> CreateCommon<T>() where T : class
        {
          
            return new Impl.Common<T>();
        }


    }
}
