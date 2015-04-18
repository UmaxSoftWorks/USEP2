using System.Windows.Forms;
using FarsiLibrary.Win;
using Search_Engines_Parser_2;

namespace TabStrip
{
    public partial class TestUserControl : UserControl
    {
        public TestUserControl()
        {
            InitializeComponent();
        }
        
        public void AddNewTabPage()
        {
            tabStrip1.AddTab(new FATabStripItem(string.Format("New Document {0}", tabStrip1.Items.Count + 1), null));
        }

        public void AddNewTabPage(string Title, Control Content)
        {
            tabStrip1.AddTab(new FATabStripItem(Title, Content));
        }

        public void RemoveLastTab()
        {
            if (tabStrip1.Items.Count > 0)
            {
                FATabStripItem item = tabStrip1.Items[tabStrip1.Items.Count - 1];
                tabStrip1.RemoveTab(item);
            }
        }

        public void RemoveTab(int Value)
        {
            if (tabStrip1.Items.Count >= Value)
            {
                tabStrip1.RemoveTab(tabStrip1.Items[Value]);
            }
        }

        public bool Contains(string Title)
        {
            bool contains = false;
            for (int i = 0; i < tabStrip1.Items.Count;i++ )
            {
                if (tabStrip1.Items[i].Title == Title)
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        private void tabStrip1_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if (SelectedItemIndex < 0)
            {
                return;
            }

            //Остановка потоков и таймеров
            if (tabStrip1.Items[SelectedItemIndex].Title == "Кейворды")
            {
                KeywordsControl newControl = tabStrip1.Items[SelectedItemIndex].Controls[0] as KeywordsControl;
                if (newControl != null)
                {
                    newControl.StopAll();
                }
            }
            else if (tabStrip1.Items[SelectedItemIndex].Title == "Ссылки")
            {
                LinksControl newControl = tabStrip1.Items[SelectedItemIndex].Controls[0] as LinksControl;
                if (newControl != null)
                {
                    newControl.StopAll();
                }
            }
            else if (tabStrip1.Items[SelectedItemIndex].Title == "Бэклинки")
            {
                BackLinksControl newControl = tabStrip1.Items[SelectedItemIndex].Controls[0] as BackLinksControl;
                if (newControl != null)
                {
                    newControl.StopAll();
                }
            }
            else if (tabStrip1.Items[SelectedItemIndex].Title == "Текст")
            {
                TextControl newControl = tabStrip1.Items[SelectedItemIndex].Controls[0] as TextControl;
                if (newControl != null)
                {
                    newControl.StopAll();
                }
            }
            else if (tabStrip1.Items[SelectedItemIndex].Title == "Сниппеты")
            {
                SnippetsControl newControl = tabStrip1.Items[SelectedItemIndex].Controls[0] as SnippetsControl;
                if (newControl != null)
                {
                    newControl.StopAll();
                }
            }
        }

        public int SelectedItemIndex
        {
            get
            {
                int selectedItemIndex = -1;

                for (int i = 0; i < tabStrip1.Items.Count; i++)
                {
                    if (tabStrip1.Items[i].Selected)
                    {
                        selectedItemIndex = i;
                        break;
                    }
                }

                return selectedItemIndex;
            }
        }
    }
}
