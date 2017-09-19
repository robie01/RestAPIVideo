using System;
using System.Collections.Generic;
using System.Linq;
using VideosMenuBLL.BO;
using VideosMenuBLL.Converter;
using VideosMenuDAL;

namespace VideosMenuBLL.Services
{
    public class RentalService : IRentalService
    {
        RentalConverter conv = new RentalConverter();
        DALFacade facade;

        public RentalService(DALFacade facade)
        {
            this.facade = facade;
        }

        public BORental Create(BORental rent)
        {
            using (var uow = facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Create(conv.Convert(rent));
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public BORental Delete(int id)
        {
			using (var uow = facade.UnitOfWork)
			{
                var rentalEntity = uow.RentalRepository.Delete(id);
				uow.Complete();
				return conv.Convert(rentalEntity);
			}
        }

        public BORental Get(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
                var rentalEntity = uow.RentalRepository.Get(Id);

				// getting single order while "Include" keyword is getting all the information of an object.
				rentalEntity.Video = uow.VideoRepository.Get(rentalEntity.VideoId); 
				return conv.Convert(rentalEntity);
			}
        }

        public List<BORental> GetAll()
        {
			using (var uow = facade.UnitOfWork)
			{
                return uow.RentalRepository.GetAll().Select(conv.Convert).ToList();
			}
		}

        public BORental Update(BORental rent)
        {
            using (var uow = facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(rent.Id);
				if (rentalEntity == null)
				{
                    throw new InvalidOperationException("Rental not found");
                }
                rentalEntity.DeliveryDate = rent.DeliveryDate;
                rentalEntity.RentalDate = rent.RentalDate;
                uow.Complete();
                return conv.Convert(rentalEntity);

            }
        }
    }
}
