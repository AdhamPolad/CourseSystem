﻿using CourseSystem.Entities;

namespace CourseSystem.Dtos.User
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
