namespace classes
{
    /// <summary> 
    /// Creates a new workItem
    /// </summary> 
    public class WorkItem
    {
        /// <summary> 
        /// Stored the job ID of the last Work Item
        /// </summary> 
        private static int currentID;

        /// <summary> 
        /// Current ID
        /// </summary> 
        protected int ID {get; set; }

        /// <summary> 
        /// The title of the workItem
        /// </summary> 
        protected string Title { get; set; }

        /// <summary> 
        /// The Description for the WorkItem
        /// </summary> 
        protected string Description { get; set; }

        /// <summary> 
        /// The time span of the job
        /// </summary> 
        protected TimeSpan jobLength {get; set;}

        /// <summary> 
        /// Work Item constructor 
        /// </summary> 
        public WorkItem()
        {
            ID=0;
            Title = "Default title";
            Description = "Default description";
            jobLength = new TimeSpan();
        }

        /// <summary> 
        /// Ubstabce constuctor that has 3 parameters
        /// </summary> 
        /// <param name="title">
        /// The name of the WorkItem 
        /// </param> 
        /// <param name="desc">
        /// Description of the workItem
        /// </param> 
        /// <param name="joblen">
        /// Length of the job
        /// </param> 
        public WorkItem(string title, string desc, TimeSpan joblen)
        {
            this.ID=GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength=joblen;
        }

        /// <summary> 
        /// Static constructor to initialise the static member currentID this constructor is called one time, automatically before any instanse of WorkItem or changeRequest is create, or currentId is referenced.
        /// </summary> 
        static WorkItem() => currentID = 0;

        /// <summary> 
        /// Returns the next ID 
        /// </summary> 
        /// <returns> nextID </returns>
        protected int GetNextID() => ++currentID;

        /// <summary> 
        /// Allows an update to an existing WorkItem 
        /// </summary> 
        /// <param name="title">
        /// Updated name of the workItem
        /// </param> 
        /// <param name="joblen">
        /// Updated time of the job length
        /// </param> 
        public void Update(string title, TimeSpan joblen)
        {
            this.Title=title;
            this.jobLength=joblen;
        }

        /// <summary> 
        /// Method to oberide the ToString method that is enhirited from System.Object class 
        /// </summary> 
        public override string ToString() => 
            $"{this.ID} - {this.Title}";
    }
}

