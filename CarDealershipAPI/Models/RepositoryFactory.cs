using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CarDealershipAPI.Data.Repositories.ADO;
using CarDealershipAPI.Data.Repositories.Mock;
using CarDealershipAPI.Models.Interfaces;

namespace CarDealershipAPI
{
    /// <summary>
    /// The Repository Factory class generates mock/ADO repositories to load onto the website
    /// based on the mode configuration in the project (Web.config)
    ///
    /// All methods behave in the same way.
    /// </summary>
    public class RepositoryFactory
    {
        public static IVehicleRepository GrabVehicleRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOVehicleRepository();
                case "MOCK":
                    return new MockVehicleRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IMakeRepository GrabMakeRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOMakeRepository();
                case "MOCK":
                    return new MockMakeRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IModelRepository GrabModelRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOModelRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static ISpecialRepository GrabSpecialRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOSpecialRepository();
                case "MOCK":
                    return new MockSpecialRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IStaffMemberRepository GrabStaffRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOStaffRepository();
                case "MOCK":
                    return new MockStaffRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IStaffRoleRepository GrabStaffRoleRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOStaffRoleRepository();
                case "MOCK":
                    return new MockStaffRoleRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IStateRepository GrabStateRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOStateRepository();
                case "MOCK":
                    return new MockStateRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IPurchaseTypeRepository GrabPurchaseTypeRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOPurchaseTypeRepository();
                case "MOCK":
                    return new MockPurchaseTypeRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IPurchaseRepository GrabPurchaseRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOPurchaseRepository();
                case "MOCK":
                    return new MockPurchaseRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IBodyStyleRepository GrabBodyStyleRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOBodyStyleRepository();
                case "MOCK":
                    return new MockBodyStyleRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static ITransmissionTypeRepository GrabTransmissionTypeRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOTransmissionRepository();
                case "MOCK":
                    return new MockTransmissionTypeRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IColorRepository GrabColorRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOColorRepository();
                case "MOCK":
                    return new MockColorRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IInteriorRepository GrabInteriorRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOInteriorRepository();
                case "MOCK":
                    return new MockInteriorRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static ISalesRepository GrabSalesRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOSalesRepository();
                case "MOCK":
                    return new MockSalesRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IContactRepository GrabContactRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "ADO":
                    return new ADOContactRepository();
                case "MOCK":
                    return new MockContactRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}