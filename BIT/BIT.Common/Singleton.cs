using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT.Common
{
    public class Singleton<T> where T : new()
    {
        private static T o = new T();
        /// <summary>
        ///Khởi tạo một Instance
        /// </summary>
        public static T Inst
        {
            get { return o; }
        }

        /// <summary>
        /// New
        /// </summary>
        public static T New
        {
            get { return new T(); }
        }
    }
}
