﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace NETMVCworkshop2.Models
{
    public class BookData
    {
        public int BOOK_ID { get; set; }
        [DisplayName("書名")]
        public string BOOK_NAME { get; set; }
        [DisplayName("圖書類別")]
        public string BOOK_CLASS_ID { get; set; }
        [DisplayName("作者")]
        public string BOOK_AUTHOR { get; set; }
        [DisplayName("購書日期")]
        public string BOOK_BOUGHT_DATE { get; set; }
        [DisplayName("出版商")]
        public string BOOK_PUBLISHER { get; set; }
        [DisplayName("內容簡介")]
        public string BOOK_NOTE { get; set; }
        [DisplayName("借閱狀態")]
        public string BOOK_STATUS { get; set; }
        [DisplayName("借閱人")]
        public string BOOK_KEEPER { get; set; }
        public string CREATE_DATE { get; set; }
        public string CREATE_USER { get; set; }
        public string MODIFY_DATE { get; set; }
        public string MODIFY_USER { get; set; }

    }
}