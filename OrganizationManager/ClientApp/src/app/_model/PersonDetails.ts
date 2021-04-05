import { Person } from "./Person";
import { Report } from "./Report";
import { Task } from "./Task";

export interface PersonDetails {
  person: Person;
  manager: Person;
  tasks: Task[];
  subordinates: Person[];
  reports: Report[];
}


