﻿using System;
using System.Threading.Tasks;
using Bravado.Data;
using Bravado.Models;
using Bravado.Models.TaskViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bravado.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] Guid id)
        {

            var task = await _context.Tasks.FindAsync(id);
            var boardId = Guid.Parse(task.BoardId);
            var board = await _context.Boards.FindAsync(boardId);
            return View(model: new TaskDetails { Task = task, Board = board });
        }

        [HttpGet]
        public IActionResult Add([FromRoute] Guid id)
        {
            return View(new Models.Task { BoardId = id.ToString() });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Models.Task task)
        {
            var routeValues = new RouteValueDictionary {
               {"id", task.BoardId}
           };
            _context.Tasks.Add(new Models.Task { Title = task.Title, Description = task.Description, BoardId = task.BoardId.ToString(), ListNum = task.ListNum });
            await _context.SaveChangesAsync();
            return RedirectToAction("Open", "Boards", routeValues);
        }


        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return View(task);
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Models.Task taskUpdate)
        {
            var task = await _context.Tasks.FindAsync(taskUpdate.Id);

            task.Title = taskUpdate.Title;
            task.Description = taskUpdate.Description;
            task.DueDate = taskUpdate.DueDate;
            task.ListNum = taskUpdate.ListNum;


            var routeValues = new RouteValueDictionary
            {
               {"id", task.Id.ToString()}
            };
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Open), "Tasks", routeValues);
        }


        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);

            var routeValues = new RouteValueDictionary
            {
                {"id", task.BoardId}
            };

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Open), "Boards", routeValues);
        }



    }
}
