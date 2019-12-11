using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvpApp.Storage;

namespace MvpApp.Controllers
{
    /// <summary>
    /// Контроллер кафедр
    /// </summary>
    public class ChairsController : DbController
    {
        /// <summary>
        /// Список кафедр
        /// GET: Chairs
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Chairs.OrderBy(a => a.Number).ToList());
        }

        // GET: Chairs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        /// <summary>
        /// Форма добавленя объекта
        /// GET: Chairs/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

            /// <summary>
        /// Создание объекта в базе данных
        /// POST: Chairs/Create
        /// </summary>
        /// <param name="chair">Кафедра</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Number,Name")] Chair chair)
        {
            // Проверка на уникальность номера
            if (db.Chairs.Where(a => a.Number == chair.Number).FirstOrDefault() != null)
            {
                // Фиксация ошибки
                ModelState.AddModelError("Number", "Такой номер уже есть в списке кафедр");
            }

            // Проверка на корректность данных
            if (ModelState.IsValid)
            {
                try
                {
                    chair.ID = Guid.NewGuid();
                    db.Chairs.Add(chair);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Дойти до самого внутреннего исключения
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    ModelState.AddModelError("Number", ex.Message);
                }
            }

            // Повторный показ формы с ошибками
            return View(chair);
        }

        /// <summary>
        /// Форма редактирования объекта
        /// GET: Chairs/Edit/5
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns></returns>
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Number,Name")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chair).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chair);
        }

        // GET: Chairs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Chair chair = db.Chairs.Find(id);
            db.Chairs.Remove(chair);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
