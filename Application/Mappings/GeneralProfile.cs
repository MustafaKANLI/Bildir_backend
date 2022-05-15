using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Addresses.Commands.CreateAddress;
using Application.Features.Addresses.Queries.GetAllAddresses;
using Application.Features.Addresses.Commands.UpdateAddress;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Features.Certificates.Queries.GetAllCertificates;
using Application.Features.Certificates.Commands.CreateCertificate;
using Application.Features.Certificates.Commands.UpdateCertificate;
using Application.Features.WorkHistories.Commands.CreateWorkHistory;
using Application.Features.WorkHistories.Queries.GetAllWorkHistories;
using Application.Features.WorkHistories.Commands.UpdateWorkHistory;
using Application.Features.Educations.Queries.GetAllEducations;
using Application.Features.Educations.Commands.CreateEducation;
using Application.Features.Educations.Queries.GetEducationById;
using Application.Features.Educations.Commands.UpdateEducation;

//project
using Application.Features.Products.Commands.CreateProject;
using Application.Features.Projects.Commands.UpdateProject;
using Application.Features.Projects.Queries.GetAllProjects;
using Application.Features.Contacts.Queries.GetAllContacts;
using Application.Features.Contacts.Commands.CreateContact;
using Application.Features.Contacts.Commands.UpdateContact;
using Application.Features.Personnels.Queries.GetAllPersonnels;
using Application.Features.Personnels.Commands.CreatePersonnel;
using Application.Features.Personnels.Commands.UpdatePersonnel;
using Application.Features.Inventories.Queries.GetAllInventories;
using Application.Features.Inventories.Commands.CreateInventory;
using Application.Features.Inventories.Commands.UpdateInventory;

//announcement
using Application.Features.Announcements.Commands.CreateAnnouncement;
using Application.Features.Announcements.Queries.GetAllAnnouncements;
using Application.Features.Announcements.Commands.UpdateAnnouncement;

//community
using Application.Features.Communities.Commands.CreateCommunity;
using Application.Features.Communities.Commands.UpdateCommunity;
using Application.Features.Communities.Queries.GetAllCommunities;
using Application.Features.Communities.Queries.GetCommunityById;
using Application.Features.Communities.Queries.GetLoggedInCommunity;

//student
using Application.Features.Students.Commands.CreateStudent;
using Application.Features.Students.Queries.GetAllStudents;
using Application.Features.Students.Commands.UpdateStudent;
using Application.Features.Students.Queries.GetStudentById;
using Application.Features.Students.Queries.GetLoggedInStudent;

//event
using Application.Features.Events.Queries.GetAllEvents;
using Application.Features.Events.Queries.GetEventById;
using Application.Features.Events.Commands.CreateEvent;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<Student, GetAllStudentsViewModel>().ReverseMap();
            CreateMap<UpdateStudentCommand, Student>();
            CreateMap<GetAllStudentsQuery, GetAllStudentsParameter>();
            CreateMap<Student, GetLoggedInStudentViewModel>().ReverseMap();
            CreateMap<Student, GetStudentByIdViewModel>().ReverseMap();
            CreateMap<Student, GetAllCommunitiesStudentViewModel>();
            CreateMap<Student, GetCommunityByIdStudentViewModel>();
            CreateMap<Student, GetLoggedInCommunityStudentViewModel>();
            CreateMap<Student, GetAllEventsStudentViewModel>();
            CreateMap<Student, GetEventByIdStudentViewModel>();

            CreateMap<CreateCommunityCommand, Community>();
            CreateMap<Community, GetCommunityByIdViewModel>().ReverseMap();
            CreateMap<UpdateCommunityCommand, Community>();
            CreateMap<GetAllCommunitiesQuery, GetAllCommunitiesParameter>();
            CreateMap<Community, GetLoggedInCommunityViewModel>().ReverseMap();
            CreateMap<Community, GetAllCommunitiesViewModel>().ReverseMap();
            CreateMap<Community, GetAllStudentsCommunityViewModel>();
            CreateMap<Community, GetStudentByIdCommunityViewModel>();
            CreateMap<Community, GetLoggedInStudentCommunityViewModel>();
            CreateMap<Community, GetAllEventsCommunityViewModel>();
            CreateMap<Community, GetEventByIdCommunityViewModel>();

            CreateMap<Event, GetAllEventsViewModel>().ReverseMap();
            CreateMap<CreateEventCommand, Event>();
            //CreateMap<UpdateEventCommand, Event>();
            CreateMap<GetAllEventsQuery, GetAllEventsParameter>();
            CreateMap<Event, GetEventByIdViewModel>();
            CreateMap<Event, GetAllStudentsEventViewModel>();
            CreateMap<Event, GetLoggedInStudentEventViewModel>();
            CreateMap<Event, GetStudentByIdEventViewModel>();
            CreateMap<Event, GetAllCommunitiesEventViewModel>();
            CreateMap<Event, GetLoggedInCommunityEventViewModel>();
            CreateMap<Event, GetCommunityByIdEventViewModel>();

            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<Category, GetAllCategoriesViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<GetAllCategoriesQuery, GetAllCategoriesParameter>();

            CreateMap<Address, GetAllAddressesViewModel>().ReverseMap();
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<UpdateAddressCommand, Address>();
            CreateMap<GetAllAddressesQuery, GetAllAddressesParameter>();

            CreateMap<Certificate, GetAllCertificatesViewModel>().ReverseMap();
            CreateMap<CreateCertificateCommand, Certificate>();
            CreateMap<UpdateCertificateCommand, Certificate>();
            CreateMap<GetAllCertificatesQuery, GetAllCertificatesParameter>();

            CreateMap<WorkHistory, GetAllWorkHistoriesViewModel>().ReverseMap();
            CreateMap<CreateWorkHistoryCommand, WorkHistory>();
            CreateMap<UpdateWorkHistoryCommand, WorkHistory>();
            CreateMap<GetAllWorkHistoriesQuery, GetAllWorkHistoriesParameter>();

            CreateMap<Project, GetAllProjectsViewModel>().ReverseMap();
            CreateMap<CreateProjectCommand, Project>();
            CreateMap<UpdateProjectCommand, Project>();
            CreateMap<GetAllProjectsQuery, GetAllProjectsParameter>();

            CreateMap<CreateAnnouncementCommand, Announcement>();
            CreateMap<Announcement, GetAllAnnouncementsViewModel>().ReverseMap();
            CreateMap<UpdateAnnouncementCommand, Announcement>();
            CreateMap<GetAllAnnouncementsQuery, GetAllAnnouncementsParameter>();

            CreateMap<Education, GetAllEducationsViewModel>().ReverseMap();
            CreateMap<CreateEducationCommand, Education>();
            CreateMap<UpdateEducationCommand, Education>();
            //CreateMap<GetAllEducationsQuery, GetAllEventsParameter>();

            CreateMap<Personnel, GetAllPersonnelsViewModel>().ReverseMap();
            CreateMap<CreatePersonnelCommand, Personnel>();
            CreateMap<UpdatePersonnelCommand, Personnel>();
            CreateMap<GetAllPersonnelsQuery, GetAllPersonnelsParameter>();

            CreateMap<Inventory, GetAllInventoriesViewModel>().ReverseMap();
            CreateMap<CreateInventoryCommand, Inventory>();
            CreateMap<UpdateInventoryCommand, Inventory>();
            CreateMap<GetAllInventoriesQuery, GetAllInventoriesParameter>();

            CreateMap<Contact, GetAllContactsViewModel>().ReverseMap();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>();
            CreateMap<GetAllContactsQuery, GetAllContactsParameter>();

        }
    }
}
