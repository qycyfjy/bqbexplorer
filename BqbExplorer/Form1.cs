using OpenMcdf;
using OpenMcdf.Extensions;
using Be.Windows.Forms;

namespace BqbExplorer
{
    public partial class Form1 : Form
    {
        private FileStream? _fileStream = null;
        private CompoundFile? _cf = null;
        private readonly HexBox _hexEditor = new();
        private readonly PictureBox _pictureBox = new();

        public Form1()
        {
            InitializeComponent();

            _pictureBox.Dock = DockStyle.Fill;
            _pictureBox.MaximumSize = new Size(512, 512);
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            _hexEditor.ReadOnly = true;
            _hexEditor.Dock = DockStyle.Fill;
            _hexEditor.SelectionBackColor = Color.CornflowerBlue;
            _hexEditor.BackColor = Color.WhiteSmoke;
            _hexEditor.LineInfoVisible = true;
            _hexEditor.UseFixedBytesPerLine = true;
            _hexEditor.StringViewVisible = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFile();
            }
        }

        private void OpenFile()
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName)) return;
            LoadFile(openFileDialog1.FileName);
        }

        private void LoadFile(string filename)
        {
            _fileStream?.Close();
            _fileStream = new FileStream(
                filename, FileMode.Open, FileAccess.Read);

            _cf?.Close();
            try
            {
                _cf = new CompoundFile(_fileStream);
            }
            catch (Exception e)
            {
                MessageBox.Show("不是有效的CFB文件", "错误");
                return;
            }

            RefreshTree();
        }

        private void RefreshTree()
        {
            entriesTreeView.Nodes.Clear();

            var root = entriesTreeView.Nodes.Add("Root Entry", openFileDialog1.SafeFileName);
            root.ImageIndex = 0;
            root.Tag = _cf!.RootStorage;

            AddNodes(root, _cf.RootStorage);
        }

        private void AddNodes(TreeNode node, CFStorage? cfs)
        {
            cfs?.VisitEntries(Visitor, false);
            return;

            void Visitor(CFItem item)
            {
                if (noPreviewItemsToolStripMenuItem.Checked && item.Name.Contains("fix")) return;
                var temp = node.Nodes.Add(item.Name, item.Name + GetSize(item));
                temp.Tag = item;

                if (item.IsStream)
                {
                    temp.ImageIndex = 1;
                    temp.SelectedImageIndex = 1;
                }
                else
                {
                    temp.ImageIndex = 0;
                    temp.SelectedImageIndex = 0;
                    AddNodes(temp, item as CFStorage);
                }
            }

            string GetSize(CFItem item) => item.IsStream ? " (" + item.Size.ToString() + ")" : "";
        }

        private void entriesTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var item = e.Node as TreeNode;
            if (item.ImageIndex == 1)
            {
                var filename = item.Name;
                var stream = item.Tag as CFStream;
                StreamDataProvider provider = null;
                try
                {
                    provider = new StreamDataProvider(stream!);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "错误");
                    return;
                }
                if (IsImage(filename))
                {
                    var bitmap = new Bitmap(new MemoryStream(provider.Bytes));
                    _pictureBox.Image = bitmap;
                    splitContainer1.Panel2.Controls.Add(_pictureBox);
                }
                else
                {
                    _hexEditor.ByteProvider = provider;
                    splitContainer1.Panel2.Controls.Add(_hexEditor);
                }
            }
        }

        private bool IsImage(string fileName)
        {
            var path = new FileInfo(fileName);
            var ext = path.Extension;
            if (".png.bmp.jpg.gif".Contains(ext))
            {
                return true;
            }

            return false;
        }
        private static void CenterPictureBox(PictureBox picBox, Bitmap picImage)
        {
            // TODO
        }
    }

    class StreamDataProvider : IByteProvider
    {
        private ByteCollection _bytes;
        public byte[] Bytes => _bytes.GetBytes();

        public StreamDataProvider(CFStream stream)
        {
            try
            {
                _bytes = new ByteCollection(stream.GetData());
            }
            catch (Exception e)
            {
                _bytes = new ByteCollection();
                throw;
            }
        }
        public byte ReadByte(long index)
        {
            return _bytes[(int)index];
        }

        public void WriteByte(long index, byte value)
        {
            throw new NotImplementedException();
        }

        public void InsertBytes(long index, byte[] bs)
        {
            throw new NotImplementedException();
        }

        public void DeleteBytes(long index, long length)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }

        public void ApplyChanges()
        {
            throw new NotImplementedException();
        }

        public bool SupportsWriteByte()
        {
            throw new NotImplementedException();
        }

        public bool SupportsInsertBytes()
        {
            throw new NotImplementedException();
        }

        public bool SupportsDeleteBytes()
        {
            throw new NotImplementedException();
        }

        public long Length
        {
            get { return _bytes.Count; }
        }
        public event EventHandler? LengthChanged;
        public event EventHandler? Changed;
    }
}