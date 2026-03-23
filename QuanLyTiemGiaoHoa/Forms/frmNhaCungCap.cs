using ClosedXML.Excel;
using QuanLyTiemGiaoHoa.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemGiaoHoa.Forms
{
    public partial class frmNhaCungCap : Form
    {
        QLTGHDbContext context = new QLTGHDbContext();
        bool xuLyThem = false;
        int id;

        bool dangTimKiem = false;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenNhaCungCap.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            List<NhaCungCap> lsp = new List<NhaCungCap>();
            lsp = context.NhaCungCap.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lsp;

            txtTenNhaCungCap.DataBindings.Clear();
            txtTenNhaCungCap.DataBindings.Add("Text", bindingSource, "TenNhaCungCap", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
            dataGridView.Columns["Hoa"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenNhaCungCap.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNhaCungCap.Text))
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    NhaCungCap lsp = new NhaCungCap();
                    lsp.TenNhaCungCap = txtTenNhaCungCap.Text;
                    context.NhaCungCap.Add(lsp);

                    context.SaveChanges();
                }
                else
                {
                    NhaCungCap lsp = context.NhaCungCap.Find(id);
                    if (lsp != null)
                    {
                        lsp.TenNhaCungCap = txtTenNhaCungCap.Text;
                        context.NhaCungCap.Update(lsp);

                        context.SaveChanges();
                    }
                }

                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa loại nhà cung cấp?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NhaCungCap lsp = context.NhaCungCap.Find(id);
                if (lsp != null)
                {
                    context.NhaCungCap.Remove(lsp);
                }
                context.SaveChanges();

                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmNhaCungCap_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";

                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow) // đọc dòng tiêu đề
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);

                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());

                                firstRow = false;
                            }
                            else // đọc dữ liệu
                            {
                                table.Rows.Add();
                                int cellIndex = 0;

                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                NhaCungCap hsx = new NhaCungCap();
                                hsx.TenNhaCungCap = r["TenNhaCungCap"].ToString();
                                context.NhaCungCap.Add(hsx);
                            }

                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            frmNhaCungCap_Load(sender, e);
                        }

                        if (firstRow)
                        {
                            MessageBox.Show("Tập tin Excel rỗng.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "NhaCungCap_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    table.Columns.AddRange(new DataColumn[2]
                    {
                new DataColumn("ID", typeof(int)),
                new DataColumn("TenNhaCungCap", typeof(string))
                    });

                    var nhaCungCap = context.NhaCungCap.ToList();

                    if (nhaCungCap != null)
                    {
                        foreach (var p in nhaCungCap)
                            table.Rows.Add(p.ID, p.TenNhaCungCap);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhaCungCap");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Nếu đang tìm → bấm lại = reset
            if (dangTimKiem)
            {
                txtTimKiem.Clear();
                frmNhaCungCap_Load(sender, e);
                dangTimKiem = false;
                return;
            }

            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ketQua = context.NhaCungCap
                .Where(x => x.TenNhaCungCap.Contains(tuKhoa))
                .ToList();

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView.DataSource = ketQua;

            dangTimKiem = true; // đánh dấu đã tìm
        }
    }
}
