﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharp.Browsers
{
    /// <summary>
    /// Browse history management methods
    /// </summary>
    public interface IHistory
    {
        /// <summary>
        /// Contains all previous documents stored for each previous request
        /// </summary>
        List<IDocument> History { get; }

        /// <summary>
        /// Stores the forward history when the back method is called 
        /// </summary>
        List<IDocument> ForwardHistory { get; }

        /// <summary>
        /// Clears browse history by re-initializing Documents
        /// </summary>
        void ClearHistory();

        /// <summary>
        /// Clears forward history
        /// </summary>
        void ClearForwardHistory();

        /// <summary>
        /// Method for navigating to last browser state by re-issuing the previous request
        /// </summary>
        IDocument Back();

        /// <summary>
        /// Method for navigating to last browser state
        /// </summary>
        /// <param name="useCache">Determines whether to re-issue request or reload last document</param>
        IDocument Back(bool useCache);

        /// <summary>
        /// Method for navigating to last browser state by re-issuing the previous request asynchronously
        /// </summary>
        Task<IDocument> BackAsync();

        /// <summary>
        /// Method for navigating to last browser state asynchronously
        /// </summary>
        /// <param name="useCache">Determines whether to re-issue request or reload last document</param>
        Task<IDocument> BackAsync(bool useCache);

        /// <summary>
        /// Navigate to next document in forward history
        /// </summary>
        /// <returns></returns>
        IDocument Forward();

        /// <summary>
        /// Navigate to next document in forward history
        /// </summary>
        /// <param name="useCache"></param>
        /// <returns></returns>
        IDocument Forward(bool useCache);

        /// <summary>
        /// Navigate to next document in forward history asynchronously
        /// </summary>
        /// <returns></returns>
        Task<IDocument> ForwardAsync();

        /// <summary>
        /// Navigate to next document in forward history asynchronously
        /// </summary>
        /// <param name="useCache"></param>
        /// <returns></returns>
        Task<IDocument> ForwardAsync(bool useCache);

        /// <summary>
        /// Max amount of history/Documents to be stored by the browser (-1 for no limit)
        /// </summary>
        int MaxHistorySize { get; set; }

        /// <summary>
        /// Refresh page, re-submits last request
        /// </summary>
        /// <returns></returns>
        IDocument Refresh();

        /// <summary>
        /// Refresh page, re-submits last request asynchronously
        /// </summary>
        /// <returns></returns>
        Task<IDocument> RefreshAsync();

    }

}
