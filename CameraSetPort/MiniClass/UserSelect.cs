using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraSetPort.MiniClass {
    public class UserSelect {

        public UserSelect(FormStart main_) {
            main = main_;
        }

        private FormStart main;

        public bool script;

        public bool copy;

        /// <summary>
        /// True is เลือกครบแล้ว
        /// </summary>
        /// <returns></returns>
        public bool Check() {
            if (!script | !copy)
            {
                return false;
            }
            return true;
        }
    }
}
