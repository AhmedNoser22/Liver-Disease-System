# Liver Disease System - Backend API

## Overview

Liver Disease System is a backend application designed to help patients connect with doctors and medical assistants. The system allows patients to book appointments, doctors to manage consultations, and medical assistants to assist with scheduling and coordination.

The project is built using RESTful API architecture and includes authentication, authorization, and full CRUD functionality.

---

## Features

- User authentication using JWT
- Role-based access control (RBAC)
- Secure password hashing
- Registration and login system
- Patient management
- Doctor management
- Medical assistant role
- Appointment booking system
- Medical records management
- Full CRUD operations
- Protected routes
- Clean and scalable project structure

---

## User Roles

### Patient
- Register and login
- Book appointments
- View personal medical records
- Receive doctor notes

### Doctor
- View assigned patients
- Access patient medical records
- Write medical notes
- Manage consultations

### Medical Assistant
- Manage appointments
- Assist in scheduling
- Support doctors in daily operations

---

## Technologies Used

- Node.js
- Express.js
- MongoDB
- Mongoose
- JSON Web Token (JWT)
- bcrypt
- REST API

---

## Project Structure

```
project-root/
│
├── controllers/
├── models/
├── routes/
├── middleware/
├── config/
├── utils/
├── server.js
└── package.json
```

---

## Installation

### 1. Clone the repository

```
git clone <repository-link>
```

### 2. Install dependencies

```
npm install
```

### 3. Create environment variables

Create a `.env` file in the root directory and add:

```
PORT=5000
MONGO_URI=your_mongodb_connection_string
JWT_SECRET=your_secret_key
```

### 4. Run the application

Development mode:

```
npm run dev
```

Production mode:

```
npm start
```

---

## API Endpoints

### Authentication

POST /api/auth/register  
POST /api/auth/login  

### Users

GET /api/users  
GET /api/users/:id  
PUT /api/users/:id  
DELETE /api/users/:id  

### Appointments

POST /api/appointments  
GET /api/appointments  
GET /api/appointments/:id  
PUT /api/appointments/:id  
DELETE /api/appointments/:id  

---

## Security

- JWT-based authentication
- Role-based authorization middleware
- Password encryption using bcrypt
- Protected routes

---

## Future Improvements

- Email notifications
- Real-time messaging
- File upload for medical reports
- Dashboard analytics
- Frontend integration
- Payment integration

---

## Author

Backend Developer
