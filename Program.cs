using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_TinhKeThuaVaDaKeThua
{
    internal class Program
    {
        public enum ThucDon
        {
            NhapDanhSachTuFile = 1,
            Xuat,
            ThemPhuongTien,
            DemLoaiKetHop,
            TimTatCaLoaiKetHop,
            TimPhuongTienTheoLoaiPhuongTien,
            TimCarSoChoCaoNhat_MotoTocDoThapNhat,
            TimCarSoChoThapNhat_MotoTocDoThapNhat,
            TimCarSoChoCaoNhat_MotoTocDoCaoNhat,
            SapXepLoaiKetHop,
            SapXepTheoTenTocDoChoNgoiTheoTruongHop,
            XoaCar,
            XoaMotorcycle,
            XoaTheoTen,
            XoaTheoTocDo,
            XoaLoaiTheoLoaiKetHop,
            Thoat
        }

        static void Main(string[] args)
        {
            DanhSachPhuongTien ds = new DanhSachPhuongTien();
            string tenFile = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\LAB8_TinhKeThuaVaDaKeThua\\LAB8_TinhKeThuaVaDaKeThua\\bin\\Debug\\data.txt";
            ds.DocTuFile(tenFile);


            while (true)
            {
                string name, type;
                int age, location;
                var list = ds.GetCollection();
                Console.Clear();
                Console.WriteLine("Chon chuc nang:");
                foreach (var item in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)item}. {item}");
                }

                Console.Write("Nhap lua chon: ");
                ThucDon chon = (ThucDon)int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case ThucDon.NhapDanhSachTuFile:
                        ds.DocTuFile(tenFile);
                        break;
                    case ThucDon.Xuat:
                        ds.PrintVehicle();
                        break;
                    case ThucDon.ThemPhuongTien:
                        Console.WriteLine("Enter vehicle type (car/motorcycle): ");
                        type = Console.ReadLine();
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter speed: ");
                        int speed = int.Parse(Console.ReadLine());
                        IVehicle vehicle = null;
                        switch (type.ToLower())
                        {
                            case "car":
                                Console.WriteLine("nhap so cho ngoi: ");
                                int number = int.Parse(Console.ReadLine());

                                vehicle = new Car
                                {
                                    Ten = name,
                                    TocDo = speed,
                                    SoChoNgoi = number
                                };
                                break;
                            case "moto":
                                vehicle = new Motorcycle
                                {
                                    Ten = name,
                                    TocDo = speed
                                };
                                break;

                            default:
                                Console.WriteLine("Unknown vehicle type.");
                                return;
                        }

                        ds.AddVehicle(vehicle);
                        break;

                    case ThucDon.DemLoaiKetHop:
                        Console.WriteLine($"so luong loai phuong tien car la: " + ds.GetCars().Count);
                        Console.WriteLine($"so luong loai phuong tien motorcycle la: " + ds.GetMotorcycles().Count);
                        Console.WriteLine($"so luong loai phuong tien la car va motorcycle la: " + ds.GetCarsAndMotorcycles().Count);
                        int carAndMoto = ds.GetMotorcycles().Count + ds.GetCars().Count;
                        Console.WriteLine($"so luong loai phuong tien la car va motorcycle la: " + carAndMoto);


                        Console.WriteLine("nhap ten phuong tien ban muon dem: ");
                        string ten = Console.ReadLine();
                        Console.WriteLine($"so luong phuong tien co ten " + ten + " la: " + ds.FilterByName(ten).Count);
                        Console.WriteLine("nhap so cho ngoi cua phuong tien ban muon dem: ");
                        int choNgoi = int.Parse(Console.ReadLine());
                        Console.WriteLine($"so luong phuong tien voi so cho ngoi " + choNgoi + " la: " + ds.FilterBySeats(choNgoi).Count);
                        Console.WriteLine("nhap toc do cua phuong tien ban muon dem: ");
                        int tocDo = int.Parse(Console.ReadLine());
                        Console.WriteLine("so luong phuong tien voi toc do " + tocDo + " la: " + ds.FilterBySpeed(tocDo).Count);
                        Console.WriteLine($"so luong phuong tien voi ten va so cho ngoi nhu tren la " + ds.FilterByNameAndSeats(ten, choNgoi).Count);
                        Console.WriteLine($"so luong phuong tien voi ten, cho ngoi, toc do nhu tren la: " + ds.FilterByNameAndSeatsAndSpeed(ten, choNgoi, tocDo).Count);


                        Console.WriteLine($"phuong tien co toc do lon nhat la: " + ds.GetMaxSpeed(list));
                        Console.WriteLine($"phuong tien voi toc do nho nhat la: " + ds.GetMinSpeed(list));
                        Console.WriteLine($"phuong tien co ten dai nhat la: " + ds.GetLongestName(list));
                        Console.WriteLine($"phuong tien co ten ngan nhat la: " + ds.GetShortestName(list));

                        break;

                    case ThucDon.TimTatCaLoaiKetHop:
                        Console.WriteLine("nhap loai phuong tien ban muon tim kiem (car/motorcycle)");
                        string loai = Console.ReadLine();
                        switch (loai)
                        {
                            case "car":
                                foreach (var s in ds.GetCars())
                                {
                                    Console.WriteLine(s);
                                }
                                break;
                            case "motorcycle":
                                foreach (var s in ds.GetMotorcycles())
                                {
                                    Console.WriteLine(s);
                                }
                                break;
                            default:
                                Console.WriteLine("ko ton tai loai phuong tien " + loai);
                                break;

                        }
                        Console.WriteLine("Nhập tên phương tiện bạn muốn tìm: ");
                        ten = Console.ReadLine();
                        var resultByName = ds.FilterByName(ten);
                        Console.WriteLine($"Phương tiện có tên '{ten}' là: " +
                                        (resultByName.Count > 0 ? string.Join(", ", resultByName) : "Không có"));

                        Console.WriteLine("Nhập số chỗ ngồi của phương tiện bạn muốn tìm: ");
                        choNgoi = int.Parse(Console.ReadLine());
                        var resultBySeats = ds.FilterBySeats(choNgoi);
                        Console.WriteLine($"Phương tiện với số chỗ ngồi {choNgoi} là: " +
                                        (resultBySeats.Count > 0 ? string.Join(", ", resultBySeats) : "Không có"));

                        Console.WriteLine("Nhập tốc độ của phương tiện bạn muốn tìm: ");
                        tocDo = int.Parse(Console.ReadLine());
                        var resultBySpeed = ds.FilterBySpeed(tocDo);
                        Console.WriteLine($"Phương tiện với tốc độ {tocDo} là: " +
                                        (resultBySpeed.Count > 0 ? string.Join(", ", resultBySpeed) : "Không có"));

                        var resultByNameAndSeats = ds.FilterByNameAndSeats(ten, choNgoi);
                        Console.WriteLine($"Phương tiện với tên và số chỗ ngồi như trên là: " +
                                        (resultByNameAndSeats.Count > 0 ? string.Join(", ", resultByNameAndSeats) : "Không có"));

                        var resultByNameAndSeatsAndSpeed = ds.FilterByNameAndSeatsAndSpeed(ten, choNgoi, tocDo);
                        Console.WriteLine($"Phương tiện với tên, chỗ ngồi, tốc độ như trên là: " +
                                        (resultByNameAndSeatsAndSpeed.Count > 0 ? string.Join(", ", resultByNameAndSeatsAndSpeed) : "Không có"));
                        Console.WriteLine($"phuong tien co toc do lon nhat la: " + ds.GetMaxSpeed(list));
                        Console.WriteLine($"phuong tien voi toc do nho nhat la: " + ds.GetMinSpeed(list));
                        Console.WriteLine($"phuong tien co ten dai nhat la: " + ds.GetLongestName(list));
                        Console.WriteLine($"phuong tien co ten ngan nhat la: " + ds.GetShortestName(list));
                        break;
                    case ThucDon.TimPhuongTienTheoLoaiPhuongTien:
                        Console.WriteLine("nhap loai phuong tien ban muon tim kiem (car/motorcycle)");
                        loai = Console.ReadLine();
                        switch (loai)
                        {
                            case "car":
                                List<IVehicle> cars = new List<IVehicle>();
                                foreach (var s in ds.GetCars())
                                {
                                    cars.Add(s);
                                }

                                Console.WriteLine($"phuong tien co ten dai nhat trong loai car la: " + ds.GetLongestName(cars).Ten);
                                Console.WriteLine($"phuong tien co ten ngan nhat trong loai car la: " + ds.GetShortestName(cars).Ten);
                                Console.WriteLine($"phuong tien co so cho ngoi nho nhat trong loai car la: " + ds.GetMinSeats(cars).Ten);
                                Console.WriteLine($"phuong tien co so cho ngoi lon nhat trong loai car la: " + ds.GetMaxSeats(cars).Ten);
                                Console.WriteLine($"phuong tien co toc do nho nhat trong loai car la: " + ds.GetMinSpeed(cars).Ten);
                                Console.WriteLine($"phuong tien co toc do lon nhat trong loai car la: " + ds.GetMaxSpeed(cars).Ten);

                                break;
                            case "motorcycle":
                                List<IVehicle> moto = new List<IVehicle>();
                                foreach (var s in ds.GetCars())
                                {
                                    moto.Add(s);
                                }

                                Console.WriteLine($"phuong tien co ten dai nhat trong loai car la: " + ds.GetLongestName(moto).Ten);
                                Console.WriteLine($"phuong tien co ten ngan nhat trong loai car la: " + ds.GetShortestName(moto).Ten);
                                Console.WriteLine($"phuong tien co so cho ngoi nho nhat trong loai car la: " + ds.GetMinSeats(moto).Ten);
                                Console.WriteLine($"phuong tien co so cho ngoi lon nhat trong loai car la: " + ds.GetMaxSeats(moto).Ten);
                                Console.WriteLine($"phuong tien co toc do nho nhat trong loai car la: " + ds.GetMinSpeed(moto).Ten);
                                Console.WriteLine($"phuong tien co toc do lon nhat trong loai car la: " + ds.GetMaxSpeed(moto).Ten);
                                break;
                            default:
                                Console.WriteLine("ko ton tai loai phuong tien " + loai);
                                break;

                        }
                        break;

                    case ThucDon.TimCarSoChoCaoNhat_MotoTocDoThapNhat:
                        Console.WriteLine("cac car co so cho ngoi cao nhat la: ");
                        foreach (var s in ds.CarWithMaxSeats())
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("cac motorcycle co toc do thap nhat la: ");
                        foreach (var s in ds.MotorcycleWithMinSpeed())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case ThucDon.TimCarSoChoThapNhat_MotoTocDoThapNhat:
                        Console.WriteLine("cac car co so cho ngoi thap nhat la: ");
                        foreach (var s in ds.CarWithMinSeats())
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("cac motorcycle co toc do cao nhat la: ");
                        foreach (var s in ds.MotorcycleWithMaxSpeed())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case ThucDon.TimCarSoChoCaoNhat_MotoTocDoCaoNhat:
                        Console.WriteLine("cac car co so cho ngoi cao nhat la: ");
                        foreach (var s in ds.CarWithMaxSeats())
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("cac motorcycle co toc do cao nhat la: ");
                        foreach (var s in ds.MotorcycleWithMaxSpeed())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case ThucDon.SapXepLoaiKetHop:
                        Console.WriteLine("danh sach sau khi sap xep tang theo loai la");
                        foreach (var s in ds.SortByVehicleType(true))
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("danh sach sau khi sap xep giam theo loai la");
                        foreach (var s in ds.SortByVehicleType(false))
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("danh sach sau khi sap xep tang theo ten la");
                        foreach (var s in ds.SortByName(true))
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("danh sach sau khi sap xep giam theo ten la");
                        foreach (var s in ds.SortByName(false))
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("danh sach sau khi sap xep tang theo toc do la");
                        foreach (var s in ds.SortBySpeed(true))
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("danh sach sau khi sap xep giam theo toc do la");
                        foreach (var s in ds.SortBySpeed(false))
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("danh sach sau khi sap xep tang theo cho ngoi la");
                        foreach (var s in ds.SortBySeats(true))
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("danh sach sau khi sap xep giam theo cho ngoi la");
                        foreach (var s in ds.SortBySeats(false))
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("sap xep theo tong hop 3 thuoc tinh: ");
                        Console.WriteLine("Loại: car/motorcycle:");
                        loai = Console.ReadLine();
                        Console.WriteLine("Trường (Name/Speed/Seats):");
                        string truong = Console.ReadLine();
                        Console.WriteLine("Tăng dần (true/false):");
                        bool tangDan = bool.Parse(Console.ReadLine());
                        var kq = ds.SortVehicles(loai, truong, tangDan);
                        foreach (var v in kq) Console.WriteLine(v);
                        break;

                    case ThucDon.SapXepTheoTenTocDoChoNgoiTheoTruongHop:
                        Console.WriteLine("sap tang theo ten, so cho ngoi, toc do");
                        foreach(var item in ds.IncreasegByNameSeatsSpeed())
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("sap tang theo ten, so cho ngoi, toc do giam");
                        foreach (var item in ds.IncreaseNameSeatsDecreaseSpeed())
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("sap tang theo ten, toc do, giam so cho ngoi");
                        foreach (var item in ds.IncreaseNameSpeedDecreaseSeats())
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("sap tang theo toc do, giam theo so cho ngoi, ten");
                        foreach (var item in ds.IncreaseSpeedDecreaseNameSeats())
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("sap giam theo ten, so cho ngoi, toc do");
                        foreach (var item in ds.DecreaseNameSpeedSeats())
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case ThucDon.XoaCar:
                        ds.RemoveCar();
                        break;

                    case ThucDon.XoaMotorcycle:
                        ds.RemoveMotorcycle();
                        break;

                    case ThucDon.XoaTheoTen:
                        Console.WriteLine("nhap ten phuong tien ban muon xoa ");
                        ten = Console.ReadLine();
                        ds.RemoveByName(ten);
                        break;


                    case ThucDon.XoaTheoTocDo:
                        Console.WriteLine("nhap so toc do ban muon (se xoa cac vehicle co toc do be hon");
                        tocDo = int.Parse(Console.ReadLine());
                        ds.RemoveBySpeedLessThan(tocDo);
                        break;

                    case ThucDon.XoaLoaiTheoLoaiKetHop:
                        


                        Console.WriteLine("Nhập loại (car/motorcycle): ");
                        string xLoai = Console.ReadLine();
                        Console.WriteLine("Nhập trường (Name/Speed/Seats): ");
                        string xTruong = Console.ReadLine();
                        Console.WriteLine("Nhập giá trị cần xóa (chuỗi cho Name, số cho Speed/Seats): ");
                        string xGiaTri = Console.ReadLine();
                        ds.RemoveByTypeAndCondition(xLoai, xTruong, xGiaTri);
                        break;

                    case ThucDon.Thoat:
                        Console.WriteLine("Thoát chương trình...");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }


            }

        }
        }
}
