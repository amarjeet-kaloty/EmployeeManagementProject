﻿namespace EmployeeManagementProject.Domain_Layer.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        protected Entity() { }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}
