﻿using DAL.Interfaces.Users;
using Factories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Users
{
    public class UserCollectionLogic
    {
        IUserCollectionRepository userRepo = UserFactory.GetUserCollectionRepository();

        public bool AddUser(User user)
        {
            IEnumerable<User> users = GetAllUsers();

            foreach (User u in users)
            {
                if (u.Username == user.Username || u.Email == user.Email)
                {
                    return false;
                }
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt());
            userRepo.AddUser(user);
            return true;
        }

        public User Login(string username, string password)
        {
            User user = GetAllUsers().ToList().Find(u => u.Username == username);

            if (user != null && user.Password == password)
            {
                return user;
            }

            //if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            //{
            //    return user;
            //}

            return null;
        }

        public User GetUserById(int id)
        {
            IEnumerable<User> users = userRepo.GetAllUsers();
            return users.ToList().Find(u => u.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepo.GetAllUsers();
        }
    }
}
