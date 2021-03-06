﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharrityAuction.Models
{
    public class LotModel
    {
        static DAO.LotDAO DAO = new CharrityAuction.DAO.LotDAO();
        #region Properties

        public int? Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Name_AM { get; set; }
        [Required]
        public string Name_EN { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        [Required]
        [AllowHtml]
        public string Description_AM { get; set; }
        [Required]
        [AllowHtml]
        public string Description_EN { get; set; }
        [Required]
        [AllowHtml]
        public string Info { get; set; }
        [Required]
        [AllowHtml]
        public string Info_AM { get; set; }
        [Required]
        [AllowHtml]
        public string Info_EN { get; set; }

        [AllowHtml]
        [Required]
        public string Policy { get; set; }
        [AllowHtml]
        [Required]
        public string Policy_AM { get; set; }
        [AllowHtml]
        [Required]
        public string Policy_EN { get; set; }
        [Required]
        public string ImageSource { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DeadLine { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime OccureDate { get; set; }

        public Decimal CurrentBid { get; set; }

       

        public Decimal Step { get; set; }
        public Decimal EstimatedValue { get; set; }
        public List<LotImages> Images { get
            {
                return LotImages.GetImagesByLotId(Convert.ToInt32(this.Id));
            }
            set { } }

        public bool isShownCelebrity { get; set; }
        public int PartnerId { get; set; }
        #endregion
        public LotModel()
        {
            this.Images = new List<LotImages>();
        }
        #region Static methods
        public static List<LotModel> GetLotById(int? Id)
        {
            return DAO.getLotById(Id);
        }
        public static List<LotModel> GetAllLotById(int? Id)
        {
            return DAO.geAlltLotById(Id);
        }
        public static List<LotModel> GetEndedLots()
        {
            return DAO.getEndedLots();
        }

        public static List<LotModel>GetLotByQuery(string query)
        {
            return DAO.getLotByQuery(query);
        }
        public static List<LotModel> GetLotByCategoryId(int CategoryId)
        {
            return DAO.getLotByCategoryId(CategoryId);
        }
        public static List<LotModel> AdminGetLotByCategoryId(int CategoryId)
        {
            return DAO.getAdminLotByCategoryId(CategoryId);
        }

        public static List<LotModel> GetLotByOrder(int id)
        {
            return DAO.getLotByOrderId(id);

        }

        public static List<LotModel> GetLotByPartnerId(int id)
        {
            return DAO.getLotByPartnerId(id);

        }

        public static List<LotModel> GetLotByCategoryIdOrder(int CategoryId,int OrderId)
        {
            return DAO.getLotByCategoryIdOrder(CategoryId,OrderId);
        }
        public static void RemoveLotById(int Id)
        {
            DAO.deleteLot(Id);
        }

        #endregion
        #region Methods
        public int Save()
        {
            return DAO.saveLot(this);
        }
        #endregion
        #region TopLot
        public static LotModel GetTopLots(int index)
        {
            return DAO.getTopLots(index);
        }
        public static void SaveTopLot(int index, int lotId)
        {
            DAO.saveTopLot(index, lotId);
        }
        #endregion
    }
    public class LotImages
    {
        public int? Id { get; set; }
        public int LotId { get; set; }
        public string Imagesource { get; set; }
        static DAO.LotDAO DAO = new CharrityAuction.DAO.LotDAO();

        public static List<LotImages> GetImagesByLotId(int lotId)
        {
            return DAO.getImagesByLotId(lotId);
        }
        public static void Delete(int id)
        {
            DAO.deleteLotImage(id);
        }
        public int Save()
        {
           return DAO.saveLotImages(this);
        }
    }
}