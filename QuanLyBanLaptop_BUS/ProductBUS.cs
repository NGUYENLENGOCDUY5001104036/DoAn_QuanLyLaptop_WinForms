using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. Thêm 'using' để BUS có thể "thấy" được DAL
using QuanLyBanLaptop_DAL;

namespace QuanLyBanLaptop_BUS
{
    public class ProductBUS
    {
        // 2. Khởi tạo Repository từ tầng DAL
        private ProductRepository repo;

        public ProductBUS()
        {
            repo = new ProductRepository();
        }

        // 3. Viết hàm cho GUI gọi
        // Hàm này chỉ đơn giản là gọi hàm của Repository
        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }
        // HÀM MỚI cho GUI gọi
        public List<string> GetUniqueBrands()
        {
            return repo.GetUniqueBrands();
        }

        // ... (Bạn đã có hàm GetUniqueBrands() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để tìm kiếm
        public List<Product> SearchProducts(string name, string brand)
        {
            return repo.SearchProducts(name, brand);
        }

        // ... (Bạn đã có hàm SearchProducts() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để thêm sản phẩm
        public void AddProduct(Product product)
        {
            // (Trong tương lai, bạn có thể thêm logic kiểm tra nghiệp vụ ở đây)
            // Ví dụ: if (product.CostPrice > product.UnitPrice) { ... }

            // Gọi tầng DAL để lưu
            repo.AddProduct(product);
        }
        // ... (Bạn đã có hàm AddProduct() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để xóa
        public void DeleteProduct(int productID)
        {
            // Chỉ cần gọi tầng DAL
            // Mọi lỗi (như lỗi khóa ngoại) sẽ được ném lên cho GUI xử lý
            repo.DeleteProduct(productID);
        }

        // ... (Bạn đã có hàm DeleteProduct() ở trên) ...

        // HÀM MỚI 1: Cho GUI gọi để lấy chi tiết
        public Product GetProductById(int productID)
        {
            return repo.GetProductById(productID);
        }

        // HÀM MỚI 2: Cho GUI gọi để cập nhật
        public void UpdateProduct(Product product)
        {
            // (Bạn có thể thêm logic kiểm tra nghiệp vụ ở đây)
            repo.UpdateProduct(product);
        }
        // (Sau này, bạn có thể thêm logic nghiệp vụ ở đây. Ví dụ:)
        // public bool AddNewProduct(Product p) 
        // {
        //     if (string.IsNullOrEmpty(p.Name))
        //         return false; // Đây là logic nghiệp vụ
        //     repo.AddProduct(p); // Đây là gọi DAL
        //     return true;
        // }


    }
}