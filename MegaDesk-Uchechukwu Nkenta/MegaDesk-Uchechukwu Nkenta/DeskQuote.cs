using System;
using System.Globalization;

namespace MegaDesk_Uchechukwu_Nkenta
{
    public class DeskQuote
    {

        public DeskQuote(Desk charges)
        {
            DeskCharges = charges;
            BillDate = DateTime.Now;
        }

        public DeskQuote(string fileRec)
        {
            string[] split = fileRec.Split('\t');
            Desk desk = new Desk();
            DeskCharges = desk;
            desk.CustomerName = split[0];
            _ = CultureInfo.InvariantCulture;
            string strDate = split[1];
            if (DateTime.TryParse(strDate, out DateTime dt))
            {
                BillDate = dt;
            }
            desk.Width = Convert.ToInt32(split[2]);
            desk.Depth = Convert.ToInt32(split[3]);
            desk.SurfaceMaterial = (DesktopMaterial)Convert.ToInt32(split[4]);
            desk.NumberOfDrawers = Convert.ToInt32(split[5]);
            desk.ProductionTime = Convert.ToInt32(split[6]);
        }

        public Desk DeskCharges { get; }

        public double BillAmount
        {
            get
            {
                return BaseDeskPrice + AddToDrawers +
                    AddToMaterial + AddToSurface +
                    RushOrderPrices;
            }
        }

        public DateTime BillDate { get; set; }

        public double BaseDeskPrice
        {
            get
            {
                return Desk.BASE_DESK_PRICE;
            }
        }

        public double AddToSurface
        {
            get
            {
                int surfaceArea = DeskCharges.Width * DeskCharges.Depth;
                if (surfaceArea > Desk.AREA_CHARGE_THRESHOLD)
                {
                    return (surfaceArea - Desk.AREA_CHARGE_THRESHOLD) *
                        Desk.AREA_CHARGE_PER_UNIT;
                }
                else
                {
                    return 0;
                }
            }
        }

        public double AddToDrawers
        {
            get
            {
                return DeskCharges.NumberOfDrawers * Desk.DRAWER_CHARGE;
            }
        }

        public double AddToMaterial
        {
            get
            {
                return (double)DeskCharges.SurfaceMaterial;
            }
        }

        public double RushOrderPrices
        {
            get
            {
                int surfaceArea = DeskCharges.Width * DeskCharges.Depth;
                double rushOrderAdditionalCosts;
                if (surfaceArea < 1000)
                {
                    switch (DeskCharges.ProductionTime)
                    {
                        case 3:
                            rushOrderAdditionalCosts = 60;
                            break;
                        case 5:
                            rushOrderAdditionalCosts = 40;
                            break;
                        case 7:
                            rushOrderAdditionalCosts = 30;
                            break;
                        default:
                            rushOrderAdditionalCosts = 0;
                            break;
                    }
                }
                else if (surfaceArea <= 2000)
                {
                    switch (DeskCharges.ProductionTime)
                    {
                        case 3:
                            rushOrderAdditionalCosts = 70;
                            break;
                        case 5:
                            rushOrderAdditionalCosts = 50;
                            break;
                        case 7:
                            rushOrderAdditionalCosts = 35;
                            break;
                        default:
                            rushOrderAdditionalCosts = 0;
                            break;
                    }
                }
                else
                {
                    switch (DeskCharges.ProductionTime)
                    {
                        case 3:
                            rushOrderAdditionalCosts = 80;
                            break;
                        case 5:
                            rushOrderAdditionalCosts = 60;
                            break;
                        case 7:
                            rushOrderAdditionalCosts = 40;
                            break;
                        default:
                            rushOrderAdditionalCosts = 0;
                            break;
                    }
                }
                return rushOrderAdditionalCosts;
            }
        }

        public string[] GridRow
        {
            get
            {
                Desk desk = DeskCharges;
                string[] row = {
                    desk.CustomerName,
                    string.Format("{0,10:dd-MMM-yy}", BillDate),
                    desk.Width.ToString(),
                    desk.Depth.ToString(),
                    desk.SurfaceArea.ToString(),
                    desk.SurfaceMaterialDetails,
                    desk.NumberOfDrawers.ToString(),
                    desk.ProductionTime.ToString() + " days",
                    string.Format("{0,10:$0.00}", BillAmount)
                };
                return row;
            }
        }

        public string MakeFileRecord()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                DeskCharges.CustomerName,
                BillDate.ToString("dd-MMM-yy"),
                DeskCharges.Width,
                DeskCharges.Depth,
                (int)DeskCharges.SurfaceMaterial,
                DeskCharges.NumberOfDrawers,
                DeskCharges.ProductionTime);
        }
    }
}