import ReactDOM from 'react-dom/client';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import App from './App';
import React from 'react';
import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import Root from './routes/root';
import ErrorPage from './error-page';
import Contact from './routes/contact';
import Index from './routes';

const router = createBrowserRouter([
    {
        path: "/",
        element: <Root />,
        errorElement: <ErrorPage />,
        children: [
            {
                index: true,
                element: <Index />
            },
            {
                path: "contacts/:contactId",
                element: <Contact />,
            }
        ]
    }
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    //<React.StrictMode>
        <RouterProvider router={router} />
    //</React.StrictMode>
);
