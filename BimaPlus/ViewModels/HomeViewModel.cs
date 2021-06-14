using Android.Widget;
using BimaPlus.LocalDatabase.Model;
using BimaPlus.Model;
using BimaPlus.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BimaPlus.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        User user;
        List<Quota> qt;

        enum Type
        {
            INTERNET,
            CALL, 
            SMS
        }

        enum PackageType
        {
            AON, 
            Unlimited,
            Happy
        }

        string ImgPath = (Device.RuntimePlatform == Device.Android) ? "{0}" : null;


        public string Balance { get; private set; }
        public string Username { get; private set; }
        public string PhoneNumber { get; private set; }
        public string CallQuota { get; private set; }
        public string InternetQuota { get; private set; }
        public string SMSQuota { get; private set; }
        public string Bonus { get; private set; }
        public string ExpiredAt { get; private set; }
        public string CardType { get; private set; }

        public bool GoogleSync { get; private set; }
        public bool FacebookSync { get; private set; }
        public bool MicrosoftSync { get; private set; }

        public string GoogleEmail { get; private set; }
        public string FacebookEmail { get; private set; }
        public string MicrosoftEmail { get; private set; }

        public int CarouselPosition { get; set; }


        public Quota SelectedItem { get; set; }

        public List<Quota> QuotaAON { get; private set; }
        public List<Quota> QuotaHappy { get; private set; }
        public List<CarouselImage> Images { get; private set; }

        public ICommand Test1 { get; private set; }
        public ICommand ToHomePage { get; private set; }

        public HomeViewModel()
        {
            QuotaInit();
            QuotaAON = new List<Quota>();
            QuotaHappy = new List<Quota>();
            string[] ImagePath = new string[] { "image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg" };
            Images = new List<CarouselImage>();
            foreach(var item in ImagePath)
            {
                Images.Add(new CarouselImage() { ImagePath = item });
            }
            init();
            user = new User
            {
                Username = "Salman Syahbani",
                Balance = "Rp. 100,000",
                PhoneNumber = "08123456789",
                ExpiredAt = "08-Apr-2036",
                CardType = "Prabayar",


                Social = new Social
                {
                    FacebookEmail = "",
                    GoogleEmail = "Salman.Syahbani@gmail.com",
                    MicrosoftEmail = "Salman.Syahbani@facebook.com",

                    MicrosoftSync = true,
                    GoogleSync = true,
                    FacebookSync = false
                },

                Package = new Package
                {
                    InternetQuota = "97",
                    CallQuota = "32",
                    SMSQuota = "1000",
                    Bonus = "270"
                }
            };

            Username = user.Username;
            PhoneNumber = user.PhoneNumber;
            Balance = user.Balance;
            CallQuota = user.Package.CallQuota;
            InternetQuota = user.Package.InternetQuota;
            SMSQuota = user.Package.SMSQuota;
            Bonus = user.Package.Bonus;
            ExpiredAt = user.ExpiredAt;
            CardType = user.CardType;


            GoogleSync = user.Social.GoogleSync;
            FacebookSync = user.Social.FacebookSync;
            MicrosoftSync = user.Social.MicrosoftSync;

            GoogleEmail = IsEmpity(user.Social.GoogleEmail);
            FacebookEmail = IsEmpity(user.Social.FacebookEmail);
            MicrosoftEmail = IsEmpity(user.Social.MicrosoftEmail);

            Test1 = new Command(async () => await PackageInfo(SelectedItem));
            ToHomePage = new Command(() => App.Current.MainPage = new AppShell());

            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>) (() =>
            {
                CarouselPosition += 1;

                if (CarouselPosition >= ImagePath.Length)
                {
                    CarouselPosition = 0;
                }
                OnPropertyChanged(nameof(CarouselPosition));
                return true;
            }));
        }

        private string IsEmpity(string email)
        {
            return (!string.IsNullOrEmpty(email)) ? email : " - "; 
        }


        private async Task NextPage(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        async Task PackageInfo(Quota Item)
        {
            if (Item == null) return;

            Page page = new PackageInfo(Item);
            page.BindingContext = new HomeViewModel();
            SelectedItem = null;
            OnPropertyChanged(nameof(SelectedItem));
            await NextPage(page);
        }

        private void QuotaInit()
        {
            qt = new List<Quota>() 
            {
                new Quota{ ID = "AON3", PackageName = "AON 3GB", Price = "15,000", Description = @"
                    1.5GB Internet Unlimited (01.00-17.00 di Semua Jaringan Tri Indonesia) selama 30 hari

                    Kuota 1.5GB (24 jam di Semua Jaringan Tri Indonesia) mengikuti masa aktif kartu

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    Keterangan: Pembelian lebih dari satu kali hanya akan mengakumulasi Kuota 3GB

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "AON3.jpg"),
                 PackageType = PackageType.AON.ToString()},

                new Quota{ PackageName = "AON 4GB", Price = "19,000", Description = @"
                    2GB Internet Unlimited (01.00-17.00 di Semua Jaringan Tri Indonesia) selama 30 hari

                    Kuota 2GB (24 jam di Semua Jaringan Tri Indonesia) mengikuti masa aktif kartu

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    Keterangan: Pembelian lebih dari satu kali hanya akan mengakumulasi Kuota 4GB

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "AON4.jpg"),
                PackageType = PackageType.AON.ToString()},

                new Quota{ PackageName = "AON 6GB", Price = "28,000", Description = @"
                    3GB Internet Unlimited (01.00-17.00 di Semua Jaringan Tri Indonesia) selama 30 hari

                    Kuota 3GB (24 jam di Semua Jaringan Tri Indonesia) mengikuti masa aktif kartu

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    Keterangan: Pembelian lebih dari satu kali hanya akan mengakumulasi Kuota 6GB

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "AON6.jpg"),
                PackageType = PackageType.AON.ToString()},

                new Quota{ PackageName = "AON 12GB", Price = "39,000", Description = @"
                    6GB Internet Unlimited (01.00-17.00 di Semua Jaringan Tri Indonesia) selama 30 hari

                    Kuota 6GB (24 jam di Semua Jaringan Tri Indonesia) mengikuti masa aktif kartu

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    Keterangan: Pembelian lebih dari satu kali hanya akan mengakumulasi Kuota 12GB

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "AON12.jpg"),
                PackageType = PackageType.AON.ToString()},

                new Quota{ PackageName = "AON 16GB", Price = "48,000", Description = @"
                    8GB Internet Unlimited (01.00-17.00 di Semua Jaringan Tri Indonesia) selama 30 hari

                    Kuota 8GB (24 jam di Semua Jaringan Tri Indonesia) mengikuti masa aktif kartu

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    Keterangan: Pembelian lebih dari satu kali hanya akan mengakumulasi Kuota 16GB

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "AON16.jpg"),
                PackageType = PackageType.AON.ToString()},

                new Quota{ ID = "H1", PackageName = "Kuota Happy 1GB 3 Hari", Price = "6,000", Description = @"
                    Kuota 1GB (24 jam di Semua Jaringan Tri Indonesia) 3 Hari

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "H1.jpg"),
                PackageType = PackageType.Happy.ToString()},

                new Quota{ PackageName = "Kuota Happy 2GB 5 Hari", Price = "12,000", Description = @"
                    Kuota 2GB (24 jam di Semua Jaringan Tri Indonesia) mengikuti masa aktif kartu

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "H2.jpg"),
                PackageType = PackageType.Happy.ToString()},

                new Quota{ PackageName = "Kuota Happy 3GB 3 Hari", Price = "10,000", Description = @"
                    Kuota 3GB (24 jam di Semua Jaringan Tri Indonesia) 3 Hari

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "H3.jpg"),
                PackageType = PackageType.Happy.ToString()},

                new Quota{ PackageName = "Kuota Happy 5GB 7 Hari", Price = "25,000", Description = @"
                    Kuota 5GB (24 jam di Semua Jaringan Tri Indonesia) 7 Hari

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "H5.jpg"),
                PackageType = PackageType.Happy.ToString()},

                new Quota{ PackageName = "Kuota Happy 6GB 5 Hari", Price = "19,000", Description = @"

                    Kuota 6GB (24 jam di Semua Jaringan Tri Indonesia) 5 hari

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "H6.jpg"),
                PackageType = PackageType.Happy.ToString()},

                new Quota{ PackageName = "Kuota Happy 9GB 10 Hari", Price = "32,000", Description = @"
                    Kuota 9GB (24 jam di Semua Jaringan Tri Indonesia) 10 Hari

                    Perpanjangan Otomatis: Ya
                    Berhenti perpanjangan: SMS ketik STOP(spasi)UNLIM16R ke 234
                    Berhenti berlangganan kuota Unlimited: STOP(spasi) UNLTD ke 234

                    *Batas pemakaian wajar berlaku. Info lengkap kunjungi https://tri.co.id/Isi-Ulang-AON
                ", QuotaType = Type.INTERNET.ToString(), Rate = 1.9f, WishList = false, ImagePath = string.Format(ImgPath, "H9.jpg"),
                PackageType = PackageType.Happy.ToString()},
            };
        }

        void init()
        {
            foreach (var item in qt)
            {
                if(item == null)
                {
                    return;
                }

                if(item.PackageName.Length > 12)
                {
                    item.PackageCardTitle = item.PackageName.Substring(0, 13) + "..";
                } else
                {
                    item.PackageCardTitle = item.PackageName;
                }

                if (item.PackageType == PackageType.AON.ToString())
                {
                    QuotaAON.Add(item);
                }
                else
                {
                    QuotaHappy.Add(item);
                }
            }
            

        }



    }
}
