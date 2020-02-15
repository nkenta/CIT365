namespace MegaDesk_Uchechukwu_Nkenta
{
    public enum DesktopMaterial
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    }
   public class Desk
    {
        public Desk()
        {
            Quote = new DeskQuote(this);
        }

        public const int MIN_WIDTH = 24;
        public const int MAX_WIDTH = 96;
        public const int MIN_DEPTH = 12;
        public const int MAX_DEPTH = 48;

        public const double BASE_DESK_PRICE = 200;
        public const double AREA_CHARGE_PER_UNIT = 1;
        public const int AREA_CHARGE_THRESHOLD = 1000;
        public const double DRAWER_CHARGE = 50;

        public string CustomerName { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        public int SurfaceArea
        {
            get
            {
                return Width * Depth;
            }
        }

        public int NumberOfDrawers { get; set; }
        public DesktopMaterial SurfaceMaterial { get; set; }
        public int ProductionTime { get; set; }
        public DeskQuote Quote { get; set; }

        public string SurfaceMaterialDetails
        {
            get
            {
                return SurfaceMaterial.ToString();
            }
        }
    }
}
