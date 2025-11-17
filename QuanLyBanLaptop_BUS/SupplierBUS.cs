using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; // Thêm 'using'

namespace QuanLyBanLaptop_BUS
{
    public class SupplierBUS
    {
        private SupplierRepository repo;

        public SupplierBUS()
        {
            repo = new SupplierRepository();
        }

        // HÀM 1: Lấy tất cả
        public List<Supplier> GetAllSuppliers()
        {
            return repo.GetAllSuppliers();
        }

        // HÀM 2: Lấy theo ID
        public Supplier GetSupplierById(int supplierID)
        {
            return repo.GetSupplierById(supplierID);
        }

        // HÀM 3: Thêm (có Validation)
        public void AddSupplier(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new System.Exception("Tên Nhà cung cấp không được để trống.");

            repo.AddSupplier(supplier);
        }

        // HÀM 4: Cập nhật (có Validation)
        public void UpdateSupplier(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new System.Exception("Tên Nhà cung cấp không được để trống.");

            repo.UpdateSupplier(supplier);
        }

        // HÀM 5: Xóa
        public void DeleteSupplier(int supplierID)
        {
            repo.DeleteSupplier(supplierID);
        }
    }
}