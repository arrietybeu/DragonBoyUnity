using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Assembly_CSharp
{
    public class Tool
    {

        public static void showMenuTool()
        {

            string[] menu = new string[] { "Tạo nhóm", "Xóa nhóm", "Sửa nhóm", "Xem nhóm" };

            MyVector myVector = new MyVector();
            for (int i = 0; i < menu.Length; i++)
            {
                myVector.addElement(new Command(menu[i], 19062006, i));
            }
            GameCanvas.menu.startAt(myVector, 3);
        }
    }
}
