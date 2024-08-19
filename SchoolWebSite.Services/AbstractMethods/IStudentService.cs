﻿using SchoolProject.Data.Entities;

namespace SchoolWebSite.Services.AbstractMethods
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAysnc(Student student);
        public Task<bool> IsNameExsit(String name);
    }
}
