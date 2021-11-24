import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  constructor() { }

  createGroup(groupName: string, groupDescription: string) {
    throw new Error('Method not implemented.');
  }
}
