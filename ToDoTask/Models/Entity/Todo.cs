﻿using System.Text.Json.Serialization;

namespace ToDoTaskServer.Models.Entity
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class Todo
    {

        /// <summary>
        /// Id Задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string NameTask { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата постановки задачи
        /// </summary>
        public DateTime StartData { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public DateTime EndData { get; set; }

        /// <summary>
        /// Внешний ключ для User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Выполняющий задачи (может быть Null т.к. это может быть общая задача)
        /// </summary>
        [JsonIgnore]
        public IEnumerable<User>? Users { get; set; }

        /// <summary>
        /// Внешний ключ для Status
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Навигационное свойство для Statuse
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Status> Statuse { get; set; }

        /// <summary>
        /// Внешний ключ для Projects
        /// </summary>
        public int ProjectsId { get; set; }

        /// <summary>
        /// Навигационное свойство для Project
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Project> Project { get; set; }
    }

}
