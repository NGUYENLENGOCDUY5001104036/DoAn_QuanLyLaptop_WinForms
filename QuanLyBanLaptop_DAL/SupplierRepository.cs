using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuanLyBanLaptop_DAL
{
    public class SupplierRepository
    {
        private string connectionString;

        public SupplierRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // HÀM 1: Lấy tất cả
        public List<Supplier> GetAllSuppliers()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Suppliers.ToList();
            }
        }

        // HÀM 2: Lấy 1 NCC bằng ID
        public Supplier GetSupplierById(int supplierID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Suppliers.FirstOrDefault(s => s.SupplierID == supplierID);
            }
        }

        // HÀM 3: Thêm NCC mới
        public void AddSupplier(Supplier supplier)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                context.Suppliers.InsertOnSubmit(supplier);
                context.SubmitChanges();
            }
        }

        // HÀM 4: Cập nhật NCC
        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                Supplier existingSupplier = context.Suppliers.FirstOrDefault(s => s.SupplierID == supplierToUpdate.SupplierID);
                if (existingSupplier != null)
                {
                    existingSupplier.Name = supplierToUpdate.Name;
                    existingSupplier.Contact = supplierToUpdate.Contact;
                    existingSupplier.Address = supplierToUpdate.Address;
                    existingSupplier.Phone = supplierToUpdate.Phone;
                    existingSupplier.Email = supplierToUpdate.Email;
                    context.SubmitChanges();
                }
            }
        }

        // HÀM 5: Xóa NCC
        public void DeleteSupplier(int supplierID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                Supplier supplierToDelete = context.Suppliers.FirstOrDefault(s => s.SupplierID == supplierID);
                if (supplierToDelete != null)
                {
                    context.Suppliers.DeleteOnSubmit(supplierToDelete);
                    // LƯU Ý: Sẽ báo lỗi nếu NCC này đã có PurchaseOrder
                    context.SubmitChanges();
                }
            }
        }
    }
}