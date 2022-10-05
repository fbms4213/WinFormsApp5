namespace WinFormsApp5;

public partial class FormMain : Form
{
    private Product? _selectedProduct;


    public FormMain()
    {
        InitializeComponent();
    }


    private void btn_load_Click(object sender, EventArgs e)
    {
        _selectedProduct = new()
        {
            Id = 1,
            Name = "Iphone 14 Pro Max",
            Discount = 0,
            Price = 3399
        };


        FillTextBoxText(_selectedProduct);
    }




    private void btn_edit_Click(object sender, EventArgs e)
    {
        if (_selectedProduct is null)
            return;


        ////  Way 1 with Constructor
        // FormEdit formEdit = new FormEdit(_selectedProduct);
        // DialogResult result = formEdit.ShowDialog();





        ////  Way 2 with Property or Field
        // FormEdit formEdit = new FormEdit();
        // formEdit.Product = _selectedProduct;
        // DialogResult result = formEdit.ShowDialog();





        ////  Way 3 with ShowDialog overloading (Method)
        FormEdit formEdit = new FormEdit(_selectedProduct);
        DialogResult result = formEdit.ShowDialog(_selectedProduct);


        if (result == DialogResult.OK)
            FillTextBoxText(formEdit.Product);
    }


    private void FillTextBoxText(Product? product)
    {
        if (product is null) 
            return;

        txt_id.Text = product.Id.ToString();
        txt_name.Text = product.Name?.ToString();
        txt_discount.Text = product.Discount.ToString();
        txt_price.Text = product.Price.ToString();
    }
}