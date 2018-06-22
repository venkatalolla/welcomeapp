# Continuous Delivery with .NET Core and Cloudbees

### Leverage enterprise Jenkins to containerize .NET Core applications in a CI/CD pipeline.

## Summary

We'll be taking a .NET application through a modern continuous delivery pipeline using Jenkins and Docker. Along the way we'll highlight why Docker is a good choice for .NET applications, common continuous delivery techniques, and what other options are available for continuous delivery, containers, and orchestration. By the end of the webinar we expect you will dismiss any reservations you have about getting started refactoring your .NET applications into a more nimble microservices architecture.


## Process

1. Developer commits some changes.
2. Hook invokes Jenkins job
3. Jenkins clones repo
4. Builds and runs tests on docker container
5. If tests pass, tag docker container with registry, name, branch, build number and ":latest"
6. push tagged image to registry
7. Registry triggers job to push new container to production
8. Docker pulls new container and tags it name-prod
8. Behold the glorious new ASCII art.
9. Ongoing service starts 

## Contingencies

Should a build fail, our pipeline should notify a slack channel and send an email to the offending committer. 
If a push is made to a non-prod branch, skip triggering push to prod environment

## Enterprise v. Open Source Jenkins

We might want to just go over these and decide which to highlight. These are the first 10
https://www.cloudbees.com/products/features

1. Curanted and verified Plugins
2. Verified Jenkins Core
3. 24/7 Support
4. CloudBees specific plugins
5. Easier installation on private cloud or on premises
6. Montly rolling releases
7. Backporting security fixes
8. Restart from checkpointed locations
9. Automated config of CD for branches and pull requests
10. Share standardized build environments across cluster of masters

# Stevie and Surya

If we're going to show this via a browser, incorporate k8s (deployment, service, etc.), we need to have some long running process. I figured it'd just be an nginx container that serves the web page written by a single execution of the sample .NET app. If I'm just using Docker, I can redirect the output of the app to a file on the host, then serve that file with another container. But I don't understand how that would work with Kubernetes. 

I figure either of you could solve this.

1. Surya - show me how to put two containers in a POD that share a volume. `dotnetapp` writes the page to a location shared with the nginx server, which keeps the POD alive. My problem is that k8s never gets in a good state because the container exits immediately.
2. Stevie - alter the Dockerfile or application so that the resulting container does not exit immediately.
