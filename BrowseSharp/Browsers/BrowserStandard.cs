﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BrowseSharp.Common.History;
using BrowseSharp.Browsers.Core;
using BrowseSharp.Common;

namespace BrowseSharp.Browsers
{
    /// <summary>
    /// Headless browser implementation that creates documents for each web request.
    /// </summary>
    public class BrowserStandard : StandardCore, IBrowser, IHistorySync
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BrowserStandard(): base()
        {

        }
        
        /// <summary>
        /// Contains all previous documents stored for each previous request
        /// </summary>
        public List<IDocument> History => _history.History;

        /// <summary>
        /// Stores the forward history when the back method is called 
        /// </summary>
        public List<IDocument> ForwardHistory
        {
            get { return _history.ForwardHistory; }
        }

        /// <summary>
        /// Clears browse history by re-initializing Documents
        /// </summary>
        public void ClearHistory()
        {
            _history.ClearHistory();
        }

        /// <summary>
        /// Clears forward history
        /// </summary>
        public void ClearForwardHistory()
        {
            _history.ClearForwardHistory();
        }

        /// <summary>
        /// Method for navigating to last browser state by re-issuing the previous request
        /// </summary>
        public IDocument Back()
        {
            return Back(false);
        }

        /// <summary>
        /// Method for navigating to last browser state
        /// </summary>
        /// <param name="useCache">Determines whether to re-issue request or reload last document</param>
        public IDocument Back(bool useCache)
        {
            IDocument oldDocument = _history.Back(useCache);
            if (useCache)
                return oldDocument;

            _restClient.BaseUrl = oldDocument.RequestUri;
            return Execute(oldDocument.Request);
        }


        /// <summary>
        /// Method for navigating to last browser state by re-issuing the previous request asynchronously
        /// </summary>
        public async Task<IDocument> BackAsync()
        {
            return await BackAsync(false);
        }

        /// <summary>
        /// Method for navigating to last browser state asynchronously
        /// </summary>
        /// <param name="useCache">Determines whether to re-issue request or reload last document</param>
        public async Task<IDocument> BackAsync(bool useCache)
        {
            IDocument oldDocument = _history.Back(useCache);
            if (useCache)
                return oldDocument;

            _restClient.BaseUrl = oldDocument.RequestUri;
            return await ExecuteTaskAsync(oldDocument.Request);
        }

        /// <summary>
        /// Navigate to next document in forward history
        /// </summary>
        /// <returns></returns>
        public IDocument Forward()
        {
            return Forward(false);
        }

        /// <summary>
        /// Navigate to next document in forward history
        /// </summary>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public IDocument Forward(bool useCache)
        {
            IDocument forwardDocument = _history.Forward(useCache);
            if (useCache)
                return forwardDocument;

            _restClient.BaseUrl = forwardDocument.RequestUri;
            return Execute(forwardDocument.Request);

        }

        /// <summary>
        /// Navigate to next document in forward history asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IDocument> ForwardAsync()
        {
            return await ForwardAsync(false);
        }

        /// <summary>
        /// Navigate to next document in forward history asynchronously
        /// </summary>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public async Task<IDocument> ForwardAsync(bool useCache)
        {

            IDocument forwardDocument = _history.Forward(useCache);
            if (useCache)
                return forwardDocument;

            _restClient.BaseUrl = forwardDocument.RequestUri;
            return await ExecuteTaskAsync(forwardDocument.Request);

        }

        /// <summary>
        /// Max amount of history/Documents to be stored by the browser (-1 for no limit)
        /// </summary>
        public int MaxHistorySize { get { return _history.MaxHistorySize; } set { _history.MaxHistorySize = value; } }

        /// <summary>
        /// Refresh page, re-submits last request
        /// </summary>
        /// <returns></returns>
        public IDocument Refresh()
        {
            IDocument oldDocument = _history.Refresh();
            _restClient.BaseUrl = oldDocument.RequestUri;
            return Execute(oldDocument.Request);
        }

        /// <summary>
        /// Refresh page, re-submits last request asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IDocument> RefreshAsync()
        {
            IDocument oldDocument = _history.Refresh();
            _restClient.BaseUrl = oldDocument.RequestUri;
            return await ExecuteTaskAsync(oldDocument.Request);
        }
    }
}