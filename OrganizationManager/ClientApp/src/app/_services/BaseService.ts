import { environment } from "../../environments/environment";

export class BaseService {
  protected getUrl(url: string) {
    return environment.serverUrl.concat(url);
  }
}
