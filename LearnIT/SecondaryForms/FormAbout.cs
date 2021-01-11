using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnIT.SecondaryForms
{
    public partial class FormAbout : Form
    {
        #region оптимизация отображения всего

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
            && (((int)m.WParam & 0xFFFF) == 5))
            {
                // Change SB_THUMBTRACK to SB_THUMBPOSITION
                m.WParam = (IntPtr)(((int)m.WParam & ~0xFFFF) | 4);
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion оптимизация отображения всего

        public FormAbout()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            textBox1.Text = "Если выбрать уже существующее название базы - она перезапишеться." +
               "\r\nНазвание базы ДОЛЖНО быть указано для разблокировки кнопок сохранение и загрузки." +
               "\r\nХранить базы нужно в папке UserPacks. Из других мест грузить не будет." +
               "\r\nПри нажатии на кнопку обновить сохраняться все вопросы и ответы." +
               "\r\nБаза автоматически сохраниться в память программы после закрытия программы или перехода из настроек на другую вкладку." +
               "\r\nЧтобы создать новую базу нужно сохранить текущую. Затем удалить из неё все записи. Далее сохранить её с новым именем." +
               "\r\nРекоммендуеться редактировать файлы только с помощью LearnIT. Иначе могут и будут возникать ошибки." +
               "\r\n Правильных ответов может быть больше одного, но засчитываться в игре они будут все-равно как один." +
               "\r\nПока вы не нажали кнопку сохранить - все изменения остануться в программе но не в файле." +
               "\r\nРазмеры столбцов можно менять" +
               "\r\nБазы создаються и храняться в папке UserPacks" +
               "\r\nПри добавлении/удалении запись сразу сохраняеться в памяти программы. При изменении после нажатии кнопок обновить/удалить/добавить либо закрытии формы" +
               "\r\nМожно не указывать все 4 варианта ответа. Но как минимум 1 должен быть правильным." +
               "\r\nПрограмму запускать через start.bat" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n" +
               "\r\n";
        }
    }
}