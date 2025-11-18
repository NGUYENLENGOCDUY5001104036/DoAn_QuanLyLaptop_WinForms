using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //(để đọc file app.config)


namespace QuanLyBanLaptop_DAL
{

    public class ProductRepository
    {

        // Tạo một biến để lưu chuỗi kết nối
        private string connectionString;

        public ProductRepository()
        {
            // LẤY chuỗi kết nối TỪ FILE APP.CONFIG
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        public List<Product> GetAllProducts()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Products.ToList(); // linq trả về 1 danh sách
            }
        }

        // HÀM MỚI: Lấy danh sách hãng duy nhất để đổ vào ComboBox
        public List<string> GetUniqueBrands()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                //LINQ
                // 1. Chọn cột Brand
                // 2. Lấy các giá trị duy nhất (Distinct)
                // 3. Bỏ qua giá trị null
                // 4. Sắp xếp theo thứ tự
                return context.Products
                              .Select(p => p.Brand)
                              .Distinct()
                              .Where(b => b != null)
                              .OrderBy(b => b)
                              .ToList();
            }
        }

        // HÀM MỚI: Tìm kiếm sản phẩm
        public List<Product> SearchProducts(string name, string brand)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Lấy tất cả sản phẩm làm truy vấn gốc
                var query = context.Products.AsQueryable();

                // 2. Lọc theo Tên (nếu người dùng có nhập tên)
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(p => p.Name.Contains(name));
                }

                // 3. Lọc theo Hãng (nếu người dùng chọn khác "Tất cả")
                if (!string.IsNullOrEmpty(brand) && brand != "Tất cả")
                {
                    query = query.Where(p => p.Brand == brand);
                }

                // 4. Thực thi truy vấn và trả về kết quả
                return query.ToList();
            }
        }


        // HÀM MỚI: Thêm một sản phẩm mới vào CSDL
        public void AddProduct(Product product)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // Dùng LINQ to SQL để "xếp hàng" cho sản phẩm mới
                context.Products.InsertOnSubmit(product);

                // Thực thi lệnh "xếp hàng" (INSERT) vào CSDL
                context.SubmitChanges();
            }
        }


        // HÀM MỚI: Xóa một sản phẩm
        public void DeleteProduct(int productID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Tìm sản phẩm cần xóa
                Product productToDelete = context.Products.FirstOrDefault(p => p.ProductID == productID);

                if (productToDelete != null)
                {
                    // 2. Đánh dấu để xóa
                    context.Products.DeleteOnSubmit(productToDelete);

                    // 3. Thực thi lệnh DELET
                    context.SubmitChanges();
                }
            }
        }



        // HÀM MỚI : Lấy 1 sản phẩm duy nhất bằng ID
        public Product GetProductById(int productID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // FirstOrDefault sẽ trả về sản phẩm, hoặc null nếu không tìm thấy
                return context.Products.FirstOrDefault(p => p.ProductID == productID);
            }
        }

        // HÀM MỚI : Cập nhật một sản phẩm đã có
        public void UpdateProduct(Product productToUpdate)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Tìm bản ghi gốc trong CSDL dựa trên ID
                Product existingProduct = context.Products.FirstOrDefault(p => p.ProductID == productToUpdate.ProductID);

                if (existingProduct != null)
                {
                    // 2. Cập nhật từng thuộc tính từ đối tượng 'productToUpdate'
                    existingProduct.Name = productToUpdate.Name;
                    existingProduct.SKU = productToUpdate.SKU;
                    existingProduct.Brand = productToUpdate.Brand;
                    existingProduct.Model = productToUpdate.Model;
                    existingProduct.CPU = productToUpdate.CPU;
                    existingProduct.RAM = productToUpdate.RAM;
                    existingProduct.Storage = productToUpdate.Storage;
                    existingProduct.GPU = productToUpdate.GPU;
                    existingProduct.ScreenSize = productToUpdate.ScreenSize;
                    existingProduct.OS = productToUpdate.OS;
                    existingProduct.CostPrice = productToUpdate.CostPrice;
                    existingProduct.UnitPrice = productToUpdate.UnitPrice;
                    existingProduct.WarrantyMonths = productToUpdate.WarrantyMonths;

                    // 3. Thực thi lệnh UPDATE
                    context.SubmitChanges();
                }
            }
        }
    }
}