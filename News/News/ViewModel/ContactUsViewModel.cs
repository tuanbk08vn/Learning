
namespace News.ViewModel
{
    public class ContactUsViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        //public ContactUsViewModel(IPublishedContent content) : base(content)
        //{
        //    Name = content.GetPropertyValue<string>("Name");
        //    Address = content.GetPropertyValue<string>("Address");
        //    Email = content.GetPropertyValue<string>("Email");
        //    Phone = content.GetPropertyValue<string>("Phone");
        //    Note = content.GetPropertyValue<string>("Note");
        //}
        //public ContactUsViewModel(RenderModel model) : base(model.Content, model.CurrentCulture)
        //{
        //    Name = model.Content.GetPropertyValue<string>("Name");
        //    Address = model.Content.GetPropertyValue<string>("Address");
        //    Email = model.Content.GetPropertyValue<string>("Email");
        //    Phone = model.Content.GetPropertyValue<string>("Phone");
        //    Note = model.Content.GetPropertyValue<string>("Note");
        //}

    }
}