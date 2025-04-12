using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_TinhKeThuaVaDaKeThua
{
    public class DanhSachPhuongTien
    {
        List<IVehicle> collection;

        public DanhSachPhuongTien()
        {
            collection = new List<IVehicle>();
        }
        public void PrintVehicle()
        {
            foreach (var animal in collection)
            {
                Console.WriteLine(animal);
            }
        }
        public void DocTuFile(string tenFile)
        {
            if (!File.Exists(tenFile))
            {
                Console.WriteLine("File không tồn tại.");
                return;
            }
            StreamReader sr = new StreamReader(tenFile);
            string s = "";
            IVehicle vehicle = null;
            while ((s = sr.ReadLine()) != null)
            {
                var parts = s.Split(',');

                string type = parts[0].Trim();
                string ten = parts[1].Trim();
                int tocDo = int.Parse(parts[2].Trim());
                int soNguoiCho = int.Parse(parts[3].Trim());

                switch (type.ToLower())
                {
                    case "car":
                        vehicle = new Car
                        {
                            Ten = ten,
                            TocDo = tocDo,
                            SoChoNgoi = soNguoiCho
                        };
                        break;
                    case "moto":
                        vehicle = new Motorcycle
                        {
                            Ten = ten,
                            TocDo = tocDo
                        };
                        break;
                   
                }
                if (vehicle != null)
                {
                    collection.Add(vehicle);
                }
            }
            sr.Close();
        }

        public List<IVehicle> GetCollection()
        {
            return collection;
        }


        //public void AddVehicle()
        //{
        //    Console.WriteLine("Enter vehicle type (car/motorcycle): ");
        //    string type = Console.ReadLine();

        //    Console.WriteLine("Enter name: ");
        //    string name = Console.ReadLine();

        //    Console.WriteLine("Enter speed: ");
        //    int speed = int.Parse(Console.ReadLine());




        //    IVehicle vehicle = null;

        //    switch (type.ToLower())
        //    {
        //        case "car":
        //            Console.WriteLine("nhap so cho ngoi: ");
        //            int number = int.Parse(Console.ReadLine());

        //            vehicle = new Car
        //            {
        //                Ten = name,
        //                TocDo = speed,
        //                SoChoNgoi = number
        //            };
        //            break;
        //        case "moto":
        //            vehicle = new Motorcycle
        //            {
        //                Ten = name,
        //                TocDo = speed
        //            };
        //            break;

        //        default:
        //            Console.WriteLine("Unknown vehicle type.");
        //            return;
        //    }

        //    collection.Add(vehicle);
        //}


        public void AddVehicle(IVehicle vehicle)
        {
            collection.Add(vehicle);
        }




        //                                  loai phuong tien
        public List<IVehicle> GetCars()
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle is Car)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }


        public DanhSachPhuongTien GetVehicleByType(string type)
        {
           DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach (var vehicle in collection)
            {
                if (string.Compare(vehicle.GetType().Name, type) == 0)
                {
                    result.AddVehicle(vehicle);
                }
            }
            return result;
        }

        public List<IVehicle> GetMotorcycles()
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle is Motorcycle)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        public List<IVehicle> GetCarsOrMotorcycles()
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle is Car || vehicle is Motorcycle)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        public List<IVehicle> GetCarsAndMotorcycles()
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle is Car && vehicle is Motorcycle) 
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        //                                              end






        //                                              loai dieu kien
        public List<IVehicle> FilterByName(string name)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle.Ten.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        public List<IVehicle> FilterBySeats(int seats)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle is Car car && car.SoChoNgoi == seats)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        public List<IVehicle> FilterBySpeed(int speed)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (vehicle.TocDo == speed)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        public List<IVehicle> FilterByNameAndSeats(string name, int seats)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (string.Compare(name, vehicle.Ten) == 0 &&
                    vehicle is Car car && car.SoChoNgoi == seats)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }


        public List<IVehicle> FilterByNameAndSpeed(string name, int speed)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (string.Compare(name, vehicle.Ten) == 0 && vehicle.TocDo == speed)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }



        public List<IVehicle> FilterByNameAndSeatsAndSpeed(string name, int seats, int speed)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (var vehicle in collection)
            {
                if (string.Compare(name, vehicle.Ten) == 0 &&
                    vehicle is Car car && car.SoChoNgoi == seats &&
                    car.TocDo == speed)
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }
        //                                          max









        //                                          loai so sanh
        public IVehicle GetMaxSpeed(List<IVehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0)
                return null;

            IVehicle max = vehicles[0];
            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i].TocDo > max.TocDo)
                {
                    max = vehicles[i];
                }
            }
            return max;
        }

        public IVehicle GetMinSpeed(List<IVehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0) return null;

            IVehicle min = vehicles[0];
            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i].TocDo < min.TocDo)
                {
                    min = vehicles[i];  // Fixed: using vehicles[i] instead of collection[i]
                }
            }
            return min;
        }

        // 1. Find vehicle with maximum seats (for Cars only)
        public IVehicle GetMaxSeats(List<IVehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0) return null;

            IVehicle maxSeatVehicle = null;
            int maxSeats = int.MinValue;

            foreach (var vehicle in vehicles)
            {
                if (vehicle is ICar car && car.SoChoNgoi > maxSeats)
                {
                    maxSeats = car.SoChoNgoi;
                    maxSeatVehicle = vehicle;
                }
            }
            return maxSeatVehicle;
        }

        // 2. Find vehicle with minimum seats (for Cars only)
        public IVehicle GetMinSeats(List<IVehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0) return null;

            IVehicle minSeatVehicle = null;
            int minSeats = int.MaxValue;

            foreach (var vehicle in vehicles)
            {
                if (vehicle is ICar car && car.SoChoNgoi < minSeats)
                {
                    minSeats = car.SoChoNgoi;
                    minSeatVehicle = vehicle;
                }
            }
            return minSeatVehicle;
        }

        // 3. Find vehicle with maximum speed (already exists as GetMaxSpeed)
        

        public IVehicle GetLongestName(List<IVehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0) return null;

            IVehicle longest = vehicles[0];
            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i].Ten.Length > longest.Ten.Length)
                {
                    longest = vehicles[i];
                }
            }
            return longest;
        }

        public IVehicle GetShortestName(List<IVehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0) return null;

            IVehicle longest = vehicles[0];
            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i].Ten.Length > longest.Ten.Length)
                {
                    longest = vehicles[i];
                }
            }
            return longest;
        }
        //                                             end










        //                                             loai phuong tien va loai dieu kien
        //public List<IVehicle> TypeVehicleAndTypeCondition (string type, string condition)
        //{
        //    List<IVehicle> result = new List<IVehicle>();
        //    switch (type)
        //    {
        //        case "car":
                    
        //            break;
        //        case "motorcycle":

        //            break;
        //    }

        //    return result;
        //}

        public int DemSoLuongPhuongTienTheoTen(string loai, string ten)
        {
            var result = GetVehicleByType(loai);
            return result.FilterByName(ten).Count;
        }

        public int DemSoLuongPhuongTienTheoChoNgoi(string loai, int choNgoi)
        {
            var result = GetVehicleByType(loai);
            return result.FilterBySeats(choNgoi).Count;
        }

        public int DemSoLuongPhuongTienTheoTocDo(string loai, int tocDo)
        {
            var result = GetVehicleByType(loai);
            return result.FilterBySpeed(tocDo).Count;
        }

        public int DemSoLuongPhuongTienTheoTenVaTocDo(string loai, string ten , int tocDo)
        {
            var result = GetVehicleByType(loai);
            return result.FilterByNameAndSpeed(ten, tocDo).Count;
        }

        public int DemSoLuongPhuongTienTheoTenVaChoNgoiVaTocDo(string loai, string ten, int choNgoi, int tocDo)
        {
            var result = GetVehicleByType(loai);
            return result.FilterByNameAndSeatsAndSpeed(ten, choNgoi, tocDo).Count;
        }


        public int DemSoLuongPhuongTienTheoTocDoMax(string loai)
        {
            DanhSachPhuongTien filteredList = GetVehicleByType(loai);
            if (filteredList.collection.Count == 0)
                return 0;
            int maxSpeed = GetMaxSpeed(filteredList.collection).TocDo;
            int count = 0;
            foreach (var item in filteredList.collection)
            {
                if (item.TocDo == maxSpeed)
                {
                    count++;
                }
            }
            return count;
        }

        public int DemSoLuongPhuongTienTheoTocDoMin(string loai)
        {
            DanhSachPhuongTien filteredList = GetVehicleByType(loai);
            if (filteredList.collection.Count == 0)
                return 0;
            int minSpeed = GetMinSpeed(filteredList.collection).TocDo;
            int count = 0;
            foreach (var item in filteredList.collection)
            {
                if (item.TocDo == minSpeed)
                {
                    count++;
                }
            }
            return count;
        }

        public int DemSoLuongPhuongTienTheoCoTenDaiNhat(string loai)
        {
            DanhSachPhuongTien filteredList = GetVehicleByType(loai);
            if (filteredList.collection.Count == 0)
                return 0;
            int max = GetLongestName(filteredList.collection).TocDo;
            int count = 0;
            foreach (var item in filteredList.collection)
            {
                if (item.Ten.Length == max)
                {
                    count++;
                }
            }
            return count;
        }

        public int DemSoLuongPhuongTienTheoCoTenNganNhat(string loai)
        {
            DanhSachPhuongTien filteredList = GetVehicleByType(loai);
            if (filteredList.collection.Count == 0)
                return 0;
            int min = GetShortestName(filteredList.collection).TocDo;
            int count = 0;
            foreach (var item in filteredList.collection)
            {
                if (item.Ten.Length == min)
                {
                    count++;
                }
            }
            return count;
        }
        //                                              ens






        public void DemSoLuong()
        {
            Console.WriteLine($"so luong loai phuong tien car la: " + GetCars().Count);
            Console.WriteLine($"so luong loai phuong tien motorcycle la: " + GetMotorcycles().Count);
            Console.WriteLine($"so luong loai phuong tien la car va motorcycle la: " + GetCarsAndMotorcycles().Count);
            int carAndMoto = GetMotorcycles().Count+GetCars().Count;
            Console.WriteLine($"so luong loai phuong tien la car va motorcycle la: " + carAndMoto);


            Console.WriteLine("nhap ten phuong tien ban muon dem: ");
            string ten = Console.ReadLine();
            Console.WriteLine($"so luong phuong tien co ten " + ten + " la: " + FilterByName(ten).Count);
            Console.WriteLine("nhap so cho ngoi cua phuong tien ban muon dem: ");
            int choNgoi = int.Parse(Console.ReadLine());
            Console.WriteLine($"so luong phuong tien voi so cho ngoi " + choNgoi + " la: " + FilterBySeats(choNgoi).Count);
            Console.WriteLine("nhap toc do cua phuong tien ban muon dem: ");
            int tocDo = int.Parse(Console.ReadLine());
            Console.WriteLine("so luong phuong tien voi toc do " + tocDo + " la: " + FilterBySpeed(tocDo).Count);
            Console.WriteLine($"so luong phuong tien voi ten va so cho ngoi nhu tren la " + FilterByNameAndSeats(ten, choNgoi).Count);
            Console.WriteLine($"so luong phuong tien voi ten, cho ngoi, toc do nhu tren la: " + FilterByNameAndSeatsAndSpeed(ten, choNgoi, tocDo).Count);


            Console.WriteLine($"phuong tien co toc do lon nhat la: " + GetMaxSpeed(collection));
            Console.WriteLine($"phuong tien voi toc do nho nhat la: " + GetMinSpeed(collection));
            Console.WriteLine($"phuong tien co ten dai nhat la: " + GetLongestName(collection));
            Console.WriteLine($"phuong tien co ten ngan nhat la: " + GetShortestName(collection));



        }

        public void TimPhuongTien()
        {
            Console.WriteLine("nhap loai phuong tien ban muon tim kiem (car/motorcycle)");
            string loai = Console.ReadLine();
            switch(loai)
            {
                case "car":
                    foreach(var s in GetCars())
                    {
                        Console.WriteLine(s);
                    }
                    break;
                case "motorcycle":
                    foreach (var s in GetMotorcycles())
                    {
                        Console.WriteLine(s);
                    }
                    break;
                default:
                    Console.WriteLine("ko ton tai loai phuong tien " + loai);
                    break;

            }
            Console.WriteLine("Nhập tên phương tiện bạn muốn tìm: ");
            string ten = Console.ReadLine();
            var resultByName = FilterByName(ten);
            Console.WriteLine($"Phương tiện có tên '{ten}' là: " +
                            (resultByName.Count > 0 ? string.Join(", ", resultByName) : "Không có"));

            Console.WriteLine("Nhập số chỗ ngồi của phương tiện bạn muốn tìm: ");
            int choNgoi = int.Parse(Console.ReadLine());
            var resultBySeats = FilterBySeats(choNgoi);
            Console.WriteLine($"Phương tiện với số chỗ ngồi {choNgoi} là: " +
                            (resultBySeats.Count > 0 ? string.Join(", ", resultBySeats) : "Không có"));

            Console.WriteLine("Nhập tốc độ của phương tiện bạn muốn tìm: ");
            int tocDo = int.Parse(Console.ReadLine());
            var resultBySpeed = FilterBySpeed(tocDo);
            Console.WriteLine($"Phương tiện với tốc độ {tocDo} là: " +
                            (resultBySpeed.Count > 0 ? string.Join(", ", resultBySpeed) : "Không có"));

            var resultByNameAndSeats = FilterByNameAndSeats(ten, choNgoi);
            Console.WriteLine($"Phương tiện với tên và số chỗ ngồi như trên là: " +
                            (resultByNameAndSeats.Count > 0 ? string.Join(", ", resultByNameAndSeats) : "Không có"));

            var resultByNameAndSeatsAndSpeed = FilterByNameAndSeatsAndSpeed(ten, choNgoi, tocDo);
            Console.WriteLine($"Phương tiện với tên, chỗ ngồi, tốc độ như trên là: " +
                            (resultByNameAndSeatsAndSpeed.Count > 0 ? string.Join(", ", resultByNameAndSeatsAndSpeed) : "Không có"));
            Console.WriteLine($"phuong tien co toc do lon nhat la: " + GetMaxSpeed(collection));
            Console.WriteLine($"phuong tien voi toc do nho nhat la: " + GetMinSpeed(collection));
            Console.WriteLine($"phuong tien co ten dai nhat la: " + GetLongestName(collection));
            Console.WriteLine($"phuong tien co ten ngan nhat la: " + GetShortestName(collection));

        }

        public void TimPhuongTienTheoDieuKien()
        {
            Console.WriteLine("nhap loai phuong tien ban muon tim kiem (car/motorcycle)");
            string loai = Console.ReadLine();
            switch (loai)
            {
                case "car":
                    List<IVehicle> cars = new List<IVehicle>();
                    foreach (var s in GetCars())
                    {
                        cars.Add(s);
                    }
                   
                    Console.WriteLine($"phuong tien co ten dai nhat trong loai car la: " + GetLongestName(cars).Ten);
                    Console.WriteLine($"phuong tien co ten ngan nhat trong loai car la: " + GetShortestName(cars).Ten);
                    Console.WriteLine($"phuong tien co so cho ngoi nho nhat trong loai car la: " + GetMinSeats(cars).Ten);
                    Console.WriteLine($"phuong tien co so cho ngoi lon nhat trong loai car la: " + GetMaxSeats(cars).Ten);
                    Console.WriteLine($"phuong tien co toc do nho nhat trong loai car la: " + GetMinSpeed(cars).Ten);
                    Console.WriteLine($"phuong tien co toc do lon nhat trong loai car la: " + GetMaxSpeed(cars).Ten);

                    break;
                case "motorcycle":
                    List<IVehicle> moto = new List<IVehicle>();
                    foreach (var s in GetCars())
                    {
                        moto.Add(s);
                    }

                    Console.WriteLine($"phuong tien co ten dai nhat trong loai car la: " + GetLongestName(moto).Ten);
                    Console.WriteLine($"phuong tien co ten ngan nhat trong loai car la: " + GetShortestName(moto).Ten);
                    Console.WriteLine($"phuong tien co so cho ngoi nho nhat trong loai car la: " + GetMinSeats(moto).Ten);
                    Console.WriteLine($"phuong tien co so cho ngoi lon nhat trong loai car la: " + GetMaxSeats(moto).Ten);
                    Console.WriteLine($"phuong tien co toc do nho nhat trong loai car la: " + GetMinSpeed(moto).Ten);
                    Console.WriteLine($"phuong tien co toc do lon nhat trong loai car la: " + GetMaxSpeed(moto).Ten);
                    break;
                default:
                    Console.WriteLine("ko ton tai loai phuong tien " + loai);
                    break;

            }
        }

        public List<IVehicle> CarWithMaxSeats()
        {
            List<IVehicle> cars = new List<IVehicle>();

            // Filter only ICar objects
            foreach (var vehicle in collection)
            {
                if (vehicle is ICar) cars.Add(vehicle);
            }

            // Get the minimum number of seats among those cars
            IVehicle maxSeatCar = GetMaxSeats(cars);

            int maxSeats = ((ICar)maxSeatCar).SoChoNgoi;

            // Return all cars with min number of seats
            return cars.Where(v => v is ICar car && car.SoChoNgoi == maxSeats).ToList();
        }

        public List<IVehicle> CarWithMinSeats()
        {
            List<IVehicle> cars = new List<IVehicle>();

            // Filter only ICar objects
            foreach (var vehicle in collection)
            {
                if (vehicle is ICar) cars.Add(vehicle);
            }

            // Get the minimum number of seats among those cars
            IVehicle minSeatCar = GetMinSeats(cars);

            int minSeats = ((ICar)minSeatCar).SoChoNgoi;

            // Return all cars with min number of seats
            return cars.Where(v => v is ICar car && car.SoChoNgoi == minSeats).ToList();
        }


        public List<IVehicle> MotorcycleWithMinSpeed()
        {
            List<IVehicle> motos = new List<IVehicle>();

            // Filter motorcycles
            foreach (var vehicle in collection)
            {
                if (vehicle is Motorcycle) motos.Add(vehicle);
            }
            IVehicle minSpeedMoto = GetMinSpeed(motos);
            

            int minSpeed = minSpeedMoto.TocDo;
            List<IVehicle> result = new List<IVehicle>();
            foreach (var moto in motos)
            {
                if (moto.TocDo == minSpeed)
                {
                    result.Add(moto);
                }
            }

            return result;
        }


        public List<IVehicle> MotorcycleWithMaxSpeed()
        {
            List<IVehicle> motos = new List<IVehicle>();

            // Filter motorcycles
            foreach (var vehicle in collection)
            {
                if (vehicle is Motorcycle) motos.Add(vehicle);
            }
            IVehicle maxSpeedMoto = GetMaxSpeed(motos);


            int maxSpeed = maxSpeedMoto.TocDo;
            List<IVehicle> result = new List<IVehicle>();
            foreach (var moto in motos)
            {
                if (moto.TocDo == maxSpeed)
                {
                    result.Add(moto);
                }
            }

            return result;
        }

        public List<IVehicle> SortByVehicleType(bool carFirst)
        {
            return carFirst
                ? collection.OrderBy(v => v is ICar ? 0 : 1).ToList()
                : collection.OrderBy(v => v is IMotorcycle ? 0 : 1).ToList();
        }

        public List<IVehicle> SortByName(bool ascending)
        {
            return ascending
                ? collection.OrderBy(v => v.Ten).ToList()
                : collection.OrderByDescending(v => v.Ten).ToList();
        }

        public List<IVehicle> SortBySpeed(bool ascending)
        {
            return ascending
                ? collection.OrderBy(v => v.TocDo).ToList()
                : collection.OrderByDescending(v => v.TocDo).ToList();
        }

        public List<ICar> SortBySeats(bool ascending)
        {
            var cars = collection.OfType<ICar>();

            return ascending
                ? cars.OrderBy(c => c.SoChoNgoi).ToList()
                : cars.OrderByDescending(c => c.SoChoNgoi).ToList();
        }


        public List<IVehicle> SortVehicles(string vehicleType , string condition , bool ascending)
        {
            var filtered = collection.AsEnumerable();

            if (!string.IsNullOrEmpty(vehicleType))
            {
                filtered = filtered.Where(v => v.GetType().Name == vehicleType);
            }

            switch (condition)
            {
                case "Name":
                    filtered = ascending
                        ? filtered.OrderBy(v => v.Ten)
                        : filtered.OrderByDescending(v => v.Ten);
                    break;

                case "Speed":
                    filtered = ascending
                        ? filtered.OrderBy(v => v.TocDo)
                        : filtered.OrderByDescending(v => v.TocDo);
                    break;

                case "Seats":
                    filtered = ascending
                        ? filtered.OrderBy(v => (v is ICar car ? car.SoChoNgoi : int.MinValue))
                        : filtered.OrderByDescending(v => (v is ICar car ? car.SoChoNgoi : int.MinValue));
                    break;
            }

            return filtered.ToList();
        }

        public List<IVehicle> IncreasegByNameSeatsSpeed()
        {
            return collection
                .OrderBy(v => v.Ten.Length)
                .ThenBy(v => (v is ICar car ? car.SoChoNgoi : 0))
                .ThenBy(v => v.TocDo)
                .ToList();
        }

        public List<IVehicle> IncreaseNameSeatsDecreaseSpeed()
        {
            return collection
                .OrderBy(v => v.Ten.Length)
                .ThenBy(v => (v is ICar car ? car.SoChoNgoi : 0))
                .ThenByDescending(v => v.TocDo)
                .ToList();
        }

        public List<IVehicle> IncreaseNameSpeedDecreaseSeats()
        {
            return collection
                .OrderBy(v => v.Ten.Length)
                .ThenByDescending(v => (v is ICar car ? car.SoChoNgoi : 0))
                .ThenBy(v => v.TocDo)
                .ToList();
        }

        public List<IVehicle> IncreaseSpeedDecreaseNameSeats()
        {
            return collection
                .OrderByDescending(v => v.Ten.Length)
                .ThenByDescending(v => (v is ICar car ? car.SoChoNgoi : 0))
                .ThenBy(v => v.TocDo)
                .ToList();
        }

        public List<IVehicle> DecreaseNameSpeedSeats()
        {
            return collection
                .OrderByDescending(v => v.Ten.Length)
                .ThenByDescending(v => (v is ICar car ? car.SoChoNgoi : 0))
                .ThenByDescending(v => v.TocDo)
                .ToList();
        }


        public void RemoveByType(string typeName)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].GetType().Name == typeName)
                {
                    collection.RemoveAt(i);
                }
            }
        }

        public void RemoveCar()
        {
            string car = "Car";
            RemoveByType(car);
        }

        public void RemoveMotorcycle()
        {
            string car = "Motorcycle";
            RemoveByType(car);
        }

        public void RemoveByName( string name)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].Ten == name)
                {
                    collection.RemoveAt(i);
                }
            }
        }

        public void RemoveBySpeedLessThan( int speedThreshold)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].TocDo < speedThreshold)
                {
                    collection.RemoveAt(i);
                }
            }
        }



        public void RemoveByTypeAndCondition(string vehicleType, string condition, string value)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                IVehicle vehicle = collection[i];

                // Check type match
                if (!string.IsNullOrEmpty(vehicleType) && vehicle.GetType().Name != vehicleType)
                    continue;

                bool match = false;

                switch (condition)
                {
                    case "Name":
                        match = vehicle.Ten.Equals(value, StringComparison.OrdinalIgnoreCase);
                        break;

                    case "Speed":
                        if (int.TryParse(value, out int speed))
                            match = vehicle.TocDo == speed;
                        break;

                    case "Seats":
                        if (vehicle is ICar car && int.TryParse(value, out int seats))
                            match = car.SoChoNgoi == seats;
                        break;
                }

                if (match)
                {
                    collection.RemoveAt(i);
                }
            }
        }


    }
}
