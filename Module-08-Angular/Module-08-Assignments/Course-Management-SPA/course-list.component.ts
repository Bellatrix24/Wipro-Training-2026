import { Component } from '@angular/core';

// Define the interface representing a course record in our system
export interface Course {
  id: number;
  title: string;
  description: string;
  instructor: string;
}

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: [] // Keeping it light and simple for this submission
})
export class CourseListComponent {
  // Hardcoded array of realistic educational courses to test our SPA layout
  courses: Course[] = [
    { 
      id: 1, 
      title: 'ASP.NET Core Web API Development', 
      description: 'Learn how to build secure RESTful services, database connections, and configure Ocelot API Gateways.', 
      instructor: 'Dr. Ramesh Babu' 
    },
    { 
      id: 2, 
      title: 'Angular SPA Architectural Foundations', 
      description: 'Master TypeScript, property/event binding, service dependencies, and building component trees.', 
      instructor: 'Prof. Sarah Jenkins' 
    },
    { 
      id: 3, 
      title: 'Docker Containerization & Kubernetes Orchestration', 
      description: 'Understand container image building, local registry uploads, and multi-service deployment scaling.', 
      instructor: 'Vikram Malhotra (Cloud Lead)' 
    }
  ];

  // Track the currently highlighted course context in memory
  selectedCourse: Course | null = null;

  constructor() {
    // Intern study note: Component initialized. Keeping it light!
  }

  // Method to update the selected course when the user clicks 'View Details'
  selectCourse(course: Course): void {
    // This updates the local state variable, triggering Angular's change detection
    this.selectedCourse = course;
  }
}
