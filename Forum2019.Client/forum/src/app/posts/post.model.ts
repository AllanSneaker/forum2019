export class Post {
    Id : number;
    Title:string;
    Content:string;
    HashTag:string;
    Comments: Comment[];
    Date: Date;
    Rate: number;

    data: Post[];
    default: boolean;
}
