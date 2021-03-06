﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task_6.Interfaces;

namespace Task_6.DAL.Users
{   
    [JsonObject]
    public class UserDataBase : IUserDataBase
    {
        [JsonProperty("Users")]
        private List<User> users;

        public UserDataBase()
        {
            users = new List<User>();
        }

        public UserDataBase(params User[] users)
        {
            this.users = new List<User>(users);
        }

        public UserDataBase(int count)
        {
            users = new List<User>(count);
        }

        [JsonIgnore]
        public int Count => users.Count;

        public IUser this[int index]
        {
            get => users[index];
        }

        public bool Add(string name, DateTime dob, int age, params IAward[] awards)
        {
            if (users.Any((x) => (x.Name == name)))
            {
                return false;
            }

            User user = new User(users.Count, name, dob, age, awards);
            users.Add(user);
            return true;
        }

        public bool Remove(IUser user)
        {
            int index = users.FindIndex(x => x.Equals(user));
           
            if(index == -1)
            {
                return false;
            }

            users.RemoveAt(index);

            for(int i = index; i < users.Count; i++)
            {
                (users[i] as User).ID--;
            }

            return true;
        }

        public IEnumerator<IUser> GetAllUsers()
        {
            return users.GetEnumerator();
        }

        public IEnumerator<IUser> GetEnumerator()
        {
            return users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
