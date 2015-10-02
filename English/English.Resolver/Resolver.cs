using Autofac;
using English.Dal;
using English.Dal.Model;
using English.Dal.Repository;
using English.Service.Infrastructures;
using English.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Resolver
{
    public class Resolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<Exercise>>().As<IRepository<Exercise>>();
            builder.RegisterType<Repository<ExerciseType>>().As<IRepository<ExerciseType>>();
            builder.RegisterType<Repository<Introduction>>().As<IRepository<Introduction>>();
            builder.RegisterType<Repository<Post>>().As<IRepository<Post>>();
            builder.RegisterType<Repository<PostReply>>().As<IRepository<PostReply>>();
            builder.RegisterType<Repository<PostReplyUserVote>>().As<IRepository<PostReplyUserVote>>();
            builder.RegisterType<Repository<User>>().As<IRepository<User>>();
            builder.RegisterType<Repository<UserExercise>>().As<IRepository<UserExercise>>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ForumService>().As<IForumService>();
            builder.RegisterType<ExerciseService>().As<IExerciseService>();
            builder.RegisterType<IntroductionService>().As<IIntroductionService>();
        }
    }
}
