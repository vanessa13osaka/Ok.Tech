﻿namespace Ok.Tech.Domain.Entities
{
    public class Product: Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

    }
}
