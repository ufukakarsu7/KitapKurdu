using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class CampaignController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Campaign
        public ActionResult Index()
        {
            var campaignList = db.Campaigns.ToList();
            return View(campaignList);
        }


        // GET: Admin/Campaign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Campaign/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Campaign campaign, HttpPostedFileBase fileUpload)
        {
            Campaign newCampaign = campaign;

            try
            {
                if (fileUpload != null)
                {
                    Guid code = Guid.NewGuid();

                    string fileName = code + Path.GetExtension(fileUpload.FileName);
                    fileName = fileName.Replace(" ", "-");

                    string fileRoute = Path.Combine(Server.MapPath("~/Uploads/CampaignImage"), fileName);
                    fileUpload.SaveAs(fileRoute);
                    newCampaign.ImageURL = fileName;
                }

                db.Campaigns.Add(newCampaign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Campaign/Edit/5
        public ActionResult Edit(int id)
        {
            var campaingEdit = db.Campaigns.Find(id);
            return View(campaingEdit);
        }

        // POST: Admin/Campaign/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Campaign campaign, HttpPostedFileBase updateFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateCampaign = db.Campaigns.Where(x => x.ID == id).SingleOrDefault();

                    updateCampaign.Title = campaign.Title;
                    updateCampaign.Description = campaign.Description;
                    updateCampaign.DateOfStart = campaign.DateOfStart;
                    updateCampaign.DateOfFinish = campaign.DateOfFinish;
                    updateCampaign.DiscountRate = campaign.DiscountRate;

                    if (updateFile != null)
                    {
                        string route = Server.MapPath("~/Uploads/CampaignImage/" + updateCampaign.ImageURL);

                        if (System.IO.File.Exists(route))
                        {
                            System.IO.File.Delete(route);
                        }

                        Guid code = Guid.NewGuid();

                        string fileName = code + Path.GetExtension(updateFile.FileName);
                        fileName = fileName.Replace(" ", "-");

                        string fileRoute = Path.Combine(Server.MapPath("~/Uploads/CampaignImage"), fileName);

                        updateFile.SaveAs(fileRoute);
                        updateCampaign.ImageURL = fileName;
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Campaign/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Campaign/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
