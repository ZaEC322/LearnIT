﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnIT
{
    public partial class FormAbout : Form
    {
        #region оптимизация отображения всего

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
            DoubleBuffered = true;
            textBox1.Text = "Если выбрать уже существующее название базы - она перезапишеться." +
               "\r\nНазвание базы ДОЛЖНО быть указано для разблокировки кнопок сохранение и загрузки." +
               "\r\nХранить базы нужно в папке UserPacks. Из других мест грузить не будет." +
               "\r\nБаза автоматически сохраниться в память программы после закрытия программы или перехода из настроек на другую вкладку." +
               "\r\nЧтобы создать новую базу нужно сохранить её с новым именем." +
               "\r\nРекоммендуеться редактировать файлы только с помощью LearnIT. Иначе могут и будут возникать ошибки." +
               "\r\nПравильных ответов может быть больше одного, но засчитываться в игре они будут все-равно как один." +
               "\r\nПока вы не нажали кнопку сохранить - все изменения остануться в программе но не в файле." +
               "\r\nРазмеры столбцов можно менять" +
               "\r\nПаки создаються и храняться в папке UserPacks" +
               "\r\nМожно не указывать все 4 варианта ответа." +
               "\r\nГорячие клавишы = Ctrl + G - перейти в тигру, CTRL + S НАСТРОЙКИ, CTRL + A ПРО ПРОГРАММУ. В игру шорткаты = 1 левый верхний вариант," +
               "2 правый верхний, q левый нижний вариант, w правый нижний вариант, запустить игру enter, след. вопрос пробел" +
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