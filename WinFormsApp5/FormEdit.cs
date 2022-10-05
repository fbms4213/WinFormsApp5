using System.Text;

namespace WinFormsApp5;

public partial class FormEdit : Form
{
    private bool _hasChanged = default;
    public Product Product { get; set; }


    public FormEdit(Product product)
    {
        InitializeComponent();

        Product = product;
        FillTextBoxText();
    }


    private void btn_save_Click(object sender, EventArgs e)
    {
        if (!_hasChanged)
        {
            DialogResult = DialogResult.OK;
            return;
        }


        StringBuilder sb = new();

        if (string.IsNullOrWhiteSpace(txt_name.Text))
            sb.Append("*Name is wrong\n");

        if (!decimal.TryParse(txt_price.Text, out decimal price))
            sb.Append("*Price is wrong\n");

        if (!byte.TryParse(txt_discount.Text, out byte discount))
            sb.Append("*Discount is wrong\n");



        if (sb.Length > 0)
        {
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }



        Product.Name = txt_name.Text;
        Product.Price = price;
        Product.Discount = discount;

        DialogResult = DialogResult.OK;
    }



    private void txt_TextChanged(object sender, EventArgs e)
        => _hasChanged = true;


    private void btn_cancel_Click(object sender, EventArgs e)
        => DialogResult = DialogResult.Cancel;




    // Data transfer -> with ShowDialog Overloading
    public DialogResult ShowDialog(Product product)
    {
        FillTextBoxText();
        Product = product;

        return ShowDialog();
    }


    private void FillTextBoxText()
    {
        txt_name.Text = Product.Name;
        txt_price.Text = Product.Price.ToString();
        txt_discount.Text = Product.Discount.ToString();

        _hasChanged = false;
    }
}